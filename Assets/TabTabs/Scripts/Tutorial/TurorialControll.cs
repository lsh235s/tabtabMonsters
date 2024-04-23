using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurorialControll : MonoBehaviour
{
    public List<TutorialBase> Tutorials;
    string NextSceneName = "";
    TutorialBase CurrentTutorial = null;
    int CurrentIndex = -1;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (CurrentTutorial != null)
        {
            CurrentTutorial.Execute(this);
        }
    }

    public void SetNextTutorial()
    {
        // ���� Ʃ�丮���� Exit() �żҵ� ȣ��
        if (CurrentTutorial != null)
        {
            CurrentTutorial.Exit();
        }
        // ��� Ʃ�丮���� �����ٸ�
        if (CurrentIndex >= Tutorials.Count-1)
        {
            CompletedTutorials();
            return;
        }
        // ���� Ʃ�丮�� ����
        CurrentIndex++;
        CurrentTutorial = Tutorials[CurrentIndex];
        
        CurrentTutorial.Enter();
    }

    public void CompletedTutorials()
    {
        CurrentTutorial = null;

        if (!NextSceneName.Equals(""))
        {
            SceneManager.LoadScene(NextSceneName);
        }
    }
}

