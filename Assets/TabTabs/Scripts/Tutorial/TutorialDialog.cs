using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialDialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText;  // UI Text ���
    public TutorialButtonEffect TutorialButtonEffect;
    public Button AttackButton;
    private string[] dialogLines;  // ��ȭ ���� �迭
    [SerializeField]public int currentLine = 0;   // ���� ��ȭ �ε���

    void Start()
    {
        TutorialButtonEffect = FindObjectOfType<TutorialButtonEffect>();
        // ��ȭ ���� �ʱ�ȭ
        dialogLines = new string[]
        {
            "�ȳ��ϼ���! ������ Ʃ�丮���� �ðԵ� 000 �Դϴ�.", // Ʃ�丮�� ĳ���Ͱ� �־���ϳ� ?
            "���͸� óġ�ϱ� ���ؼ���",
            "������ ���ͺ��� ���ݹ�ư�� ������ ó���ؾ� �մϴ�.",
            // ���ݹ�ư�� �����̰� �ȴ�.
            "������ ��������Ʈ�� Ȯ���ϰ� �����ϰ� �����ϼ��� !",
            "���� ���ݹ�ư�� ��ġ �غ����� !",
            // ���ݹ�ư�� �����Եȴٸ� �����̴� ȿ�� off
            "������ ��������Ʈ �̻��� ������ �ϰ� �ȴٸ�",
            "������ ������ �˴ϴ�.",
            // ������� �����ʸ��� ���� ����
            "������ ���͸� ó���ߴٸ�, �뽬��ư�� ������",
            // �뽬��ư�� �����̰� �ȴ�.
            "���� ���Ϳ� �̵����� �� ���� ���͸�",
            "óġ�ϼ���!",
            // ���� ���� óġ �� 
            "���� ���͸� óġ�ߴٸ� �ٽ� ������ ���͸�",
            "óġ�ϴ� ������� ����ǰ� �ȴ�ϴ�",
            // 1. Timebar���� �����̰� �ȴ�. 2. 1���� Timebar�� �ð��� �پ��� �ȴ�.
            "��! ��ܿ� �ð��� �ٰ��־��",
            // Ʃ�丮�󿡼��� Timebar�� 50%�� �����ؼ� �ִ� 10%������ �پ��� ����
            "�ð��� �����ԵǸ� ���������� ������ ������ �˴ϴ�.",
            "������ ��������Ʈ�� �����ϸ� �ð��� �þ�� �ȴ�ϴ�.",
            "�ִ��� ���� ���͸� óġ�ϰ� ������ ȹ���ؼ�",
            "�ְ����� ���������� !",
            "�̻����� Ʃ�丮���� ��ġ�ڽ��ϴ�!",
            "������ ������ ���ϴ�!"
            // 1. Skip��ư�� Go��ư���� ���� 2. Go��ư�� �����̰� �ȴ�. 3. Go��ư�� ������ �κ������ �̵�
        };

        // �ʱ� ��ȭ ǥ��
        ShowDialog();
    }

    void Update()
    {
        // '����' ��ư�� ������ ���� ��ȭ�� ����
        if (Input.GetMouseButtonDown(0)) // �����ȯ������ ��ȯ�� Input.touchCount > 0 (�׽�Ʈ �� ���濹��)
        {
            NextLine();
        }
    }

    void NextLine()
    {
        if (currentLine < dialogLines.Length - 1)
        {
            currentLine++;
            ShowDialog();
        }
        else
        {
            // ��ȭ�� ������ �� ó�� (��: ��ȭâ �ݱ�)
            Debug.Log("��ȭ ����");
        }
    }

    void ShowDialog()
    {
        string currentDialog = dialogLines[currentLine];
        // ���� ��ȭ ������ �ؽ�Ʈ UI�� ǥ��
        dialogText.text = dialogLines[currentLine];
    }

}
