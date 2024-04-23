using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using TMPro; 

public class PurchaseManager : MonoBehaviour, IStoreListener
{
    [Header("Product ID")]
    public readonly string productId_test_id = "purchase_ads";
    public readonly string productId_test_id2 = "purchase_gold";


    [Header("Cache")]
    private IStoreController storeController; //구매 과정을 제어하는 함수 제공자
    private IExtensionProvider storeExtensionProvider; //여러 플랫폼을 위한 확장 처리 제공자

    [SerializeField] private GameObject popMessage; //튜토리얼 캔버스

    private void Start()
    {
        InitUnityIAP(); //Start 문에서 초기화 필수
    }

    /* Unity IAP를 초기화하는 함수 */
    private void InitUnityIAP()
    {
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        /* 구글 플레이 상품들 추가 */
        builder.AddProduct(productId_test_id, ProductType.Consumable, new IDs() { { productId_test_id, GooglePlay.Name } });
        builder.AddProduct(productId_test_id2, ProductType.Consumable, new IDs() { { productId_test_id2, GooglePlay.Name } });

        UnityPurchasing.Initialize(this, builder);
    }

    /* 구매하는 함수 */
    public void Purchase(string productId)
    {
        Product product = storeController.products.WithID(productId); //상품 정의

        if (product != null && product.availableToPurchase) //상품이 존재하면서 구매 가능하면
        {
            storeController.InitiatePurchase(product); //구매가 가능하면 진행
        }
        else //상품이 존재하지 않거나 구매 불가능하면
        {
            Debug.Log("상품이 없거나 현재 구매가 불가능합니다");
        }
    }

    #region Interface
    /* 초기화 성공 시 실행되는 함수 */
    public void OnInitialized(IStoreController controller, IExtensionProvider extension)
    {
        Debug.Log("초기화에 성공했습니다");

        storeController = controller;
        storeExtensionProvider = extension;
    }

    /* 초기화 실패 시 실행되는 함수 */
    public void OnInitializeFailed(InitializationFailureReason error, string errorMessage)
    {
        Debug.Log("초기화에 실패했습니다: " + error.ToString() + ", " + errorMessage);
    }

    /* 초기화 실패 시 실행되는 함수 */
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("초기화에 실패했습니다: " + error.ToString());
    }

    /* 구매에 실패했을 때 실행되는 함수 */
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("구매에 실패했습니다");
    }

    /* 구매를 처리하는 함수 */
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log("구매에 성공했습니다");
        Debug.Log("productId_test_id:"+args.purchasedProduct.definition.id);
        
        BackEndManager.Instance.PurchaseBackend(args);
   
        if (args.purchasedProduct.definition.id == productId_test_id)
        {
            /* test_id 구매 처리 */
            DataManager.Instance.playerData.AdsYn = 1;
            DataManager.Instance.playerData.AdsDate = System.DateTime.Now.ToString();
            DataManager.Instance.playerData.Gold += 3000;
            DataManager.Instance.DbSaveGameData();

            popMessage.SetActive(true);
             // "Purchase_message" GameObject 내부의 "Purchase_Text" GameObject를 찾음
            Transform purchaseTextTransform = popMessage.transform.Find("Purchase_Text");
            Debug.Log("purchaseTextTransform:"+purchaseTextTransform);

                // TextMeshPro 컴포넌트를 얻음
            TextMeshProUGUI purchaseText = popMessage.GetComponentInChildren<TextMeshProUGUI>(true);
            purchaseText.text = "광고 제거 상품 및 3000 Gold구매 완료 되었습니다.";
        

        }
        else if (args.purchasedProduct.definition.id == productId_test_id2)
        {
            /* test_id2 구매 처리 */
            DataManager.Instance.playerData.Gold += 2000;
            DataManager.Instance.DbSaveGameData();

            popMessage.SetActive(true);
             // "Purchase_message" GameObject 내부의 "Purchase_Text" GameObject를 찾음
            Transform purchaseTextTransform = popMessage.transform.Find("Purchase_Text");

                // TextMeshPro 컴포넌트를 얻음
            TextMeshProUGUI purchaseText = popMessage.GetComponentInChildren<TextMeshProUGUI>(true);
            purchaseText.text = "2000 Gold구매 완료 되었습니다.";
         

        } else if (args.purchasedProduct.definition.id == "purchase_test") {
            DataManager.Instance.playerData.AdsYn = 1;
            DataManager.Instance.playerData.AdsDate = System.DateTime.Now.ToString();
            DataManager.Instance.playerData.Gold += 3000;
            DataManager.Instance.DbSaveGameData();

   
        }
        return PurchaseProcessingResult.Complete;
    }
    #endregion
}
