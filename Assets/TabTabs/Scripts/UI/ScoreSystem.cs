using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    public int score;
    public static int bestScore; // ĳ������ �ְ��� ����� ����
    public static int swordGirl1BestScore;
    public static int swordGirl2BestScore;
    public static int swordGirl3BestScore;
    public static int leonBestScore;
    public int swordGirl1PreviousBestScore = 0;
    public int swordGirl2PreviousBestScore = 0;
    public int swordGirl3PreviousBestScore = 0;
    public int leonPreviousBestScore = 0;
    public Image newScoreImage;

    void Start()
    {
        swordGirl1PreviousBestScore = DataManager.Instance.swordGirl1.bestScore;
        swordGirl2PreviousBestScore = DataManager.Instance.swordGirl2.bestScore;
        swordGirl3PreviousBestScore = DataManager.Instance.swordGirl3.bestScore;
        leonPreviousBestScore = DataManager.Instance.leon.bestScore;
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    void Update()
    {
        scoreText.text = score.ToString();

        // score�� ���� ĳ���Ͱ� �������ִ� ����Ʈ���ھ�� ũ�ٸ� score�� ĳ������ ����Ʈ ���ھ�� �����
        if (SelectCharacter.swordGirl1 && score > DataManager.Instance.swordGirl1.bestScore)
        {
            newScoreImage.gameObject.SetActive(true);
            DataManager.Instance.swordGirl1.bestScore = score;
            DataManager.Instance.SaveGameData();
        }
        else if (SelectCharacter.swordGirl2 && score > DataManager.Instance.swordGirl2.bestScore)
        {
            newScoreImage.gameObject.SetActive(true);
            DataManager.Instance.swordGirl2.bestScore = score;
            DataManager.Instance.SaveGameData();
        }
        else if (SelectCharacter.swordGirl3 && score > DataManager.Instance.swordGirl3.bestScore)
        {
            newScoreImage.gameObject.SetActive(true);
            DataManager.Instance.swordGirl3.bestScore = score;
            DataManager.Instance.SaveGameData();
        }
        else if (SelectCharacter.leon && score > DataManager.Instance.leon.bestScore)
        {
            newScoreImage.gameObject.SetActive(true);
            DataManager.Instance.leon.bestScore = score;
            DataManager.Instance.SaveGameData();
        }
        else
        {
            newScoreImage.gameObject.SetActive(false);
            return;
        }
    }
}
