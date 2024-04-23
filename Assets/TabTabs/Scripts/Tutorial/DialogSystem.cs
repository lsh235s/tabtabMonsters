using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private Speaker[] Speakers;
    [SerializeField]
    private DialogData[] Dialogs; // ����� ��� �迭
    [SerializeField]
    private bool isAutoStart = true;
    private bool isFirst = true; // ���� 1ȸ�� ȣ�� �ϴ����� ����
    private int CurrentDialogIndex = -1; // ���� ��� ����
    private int CurrentSpeakerIndex = 0;
    private float TypingSpeed = 0.1f; // �ý�Ʈ Ÿ���� ȿ���� ����ӵ�
    private bool IsTypingEffect = false; // �ý�Ʈ Ÿ���� ȿ���� ����������� ����


    private void Awake()
    {
        TutorialSetup();
    }

    private void TutorialSetup()
    {
        for (int i = 0; i < Speakers.Length; i++)
        {
            SetActiveObject(Speakers[i], false);
            Speakers[i].Leon.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        if (isFirst == true)
        {
            TutorialSetup();

            if (isAutoStart)
            {
                SetNextDialog();
            }
            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (IsTypingEffect == true)
            {
                IsTypingEffect = false;

                // Ÿ���� ȿ���� �����ϰ�, ���� ��縦 ��ü ���
                StopCoroutine("OnTypingText");
                Speakers[CurrentSpeakerIndex].TextDialog.text = Dialogs[CurrentDialogIndex].Dialogues;
                // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
                Speakers[CurrentSpeakerIndex].ObjectArrow.SetActive(true);
                return false;
            }


            if (Dialogs.Length > CurrentDialogIndex +1)
            {// ��簡 ���̻� �������
                SetNextDialog();
            }
            else
            {// ���̻� ��ȭ�� �������� �ʴٸ�
                for (int i = 0; i < Speakers.Length; i++)
                {
                    SetActiveObject(Speakers[i], false);
                    Speakers[i].Leon.SetActive(false);
                }
                // Skip��ư�� Go��ư���� ����
                // �� ��ȯ
                return true;
            }

        }
        return false;
    }

    public void SetNextDialog()
    {
        SetActiveObject(Speakers[CurrentSpeakerIndex], false);
        CurrentDialogIndex++;
        CurrentSpeakerIndex = Dialogs[CurrentDialogIndex].SpeakerIndex;
        SetActiveObject(Speakers[CurrentSpeakerIndex], true);
        Speakers[CurrentSpeakerIndex].TextName.text = Dialogs[CurrentDialogIndex].Name;
        Speakers[CurrentSpeakerIndex].TextDialog.text = Dialogs[CurrentDialogIndex].Dialogues;

        StartCoroutine("OnTypingText"); // Ÿ������ �ѱ��ھ� ����ϵ���
    }

    public void SetActiveObject(Speaker speaker, bool visible)
    {
        speaker.ImageDialog.gameObject.SetActive(visible);
        speaker.TextName.gameObject.SetActive(visible);
        speaker.TextDialog.gameObject.SetActive(visible);
        //speaker.ImageArrow.gameObject.SetActive(visible);
        speaker.Leon.SetActive(visible);

        speaker.ObjectArrow.SetActive(false);
        // ��ȭ�� ����Ǿ������� Ȱ��ȭ(��ȭâ �������ϴ��� ���ο�)
    }

    IEnumerator OnTypingText()
    {
        int index = 0;

        IsTypingEffect = true;
        audioManager.Instance.SfxAudioPlay("Tutorial_Text"); // ��ȭâ�� �ؽ�Ʈ ��½� ����Ǵ� �����
        // �ý��� �ѱ��ھ� ���
        while (index < Dialogs[CurrentDialogIndex].Dialogues.Length+1)
        {
            Speakers[CurrentDialogIndex].TextDialog.text = Dialogs[CurrentDialogIndex]
                .Dialogues.Substring(0, index);
            index++;
            yield return new WaitForSeconds(TypingSpeed);
        }

        IsTypingEffect = false;

        // ��簡 �Ϸ�Ǿ����� ��µǴ� Ŀ�� Ȱ��ȭ
        Speakers[CurrentSpeakerIndex].ObjectArrow.SetActive(true);
    }
}
[System.Serializable]
public struct Speaker
{
    public GameObject Leon;
    public Image ImageDialog; // ��ȭâ Image UI
    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextDialog;
    public GameObject ObjectArrow; // ���Ϸ�� ��µǴ� ���ο�
    //public Image ImageArrow;
}
[System.Serializable]
public struct DialogData
{
    public int SpeakerIndex; // ��ȭ�� ������ ����
    public string Name; // ĳ���� �̸�
    public string Dialogues; // ���
}
