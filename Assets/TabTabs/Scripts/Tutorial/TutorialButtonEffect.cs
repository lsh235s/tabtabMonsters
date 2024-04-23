using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtonEffect : MonoBehaviour
{
    public Button button;  // UI ��ư
    public Sprite NormalImage;
    public Sprite AfterImage;
    private Image ButtonImage;
    private bool isNormalImage = true;
    public bool Repeat = true;
    public TutorialDialog TutorialDialog;
    private void Start()
    {
        TutorialDialog = FindObjectOfType<TutorialDialog>();
        ButtonImage = button.GetComponent<Image>();
        ButtonImage.sprite = NormalImage;
        StartCoroutine(SwitchImagesRepeatedly());
    }

    public IEnumerator SwitchImagesRepeatedly()
    {
        if (Repeat && TutorialDialog.currentLine == 2)
        {
            while (true)
            {
                // �̹��� ��ȯ
                if (isNormalImage)
                {
                    ButtonImage.sprite = AfterImage;
                }
                else
                {
                    ButtonImage.sprite = NormalImage;
                }

                // ���� ����
                isNormalImage = !isNormalImage;

                // 0.5�� ���
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
