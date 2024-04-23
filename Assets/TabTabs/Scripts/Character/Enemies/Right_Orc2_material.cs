using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TabTabs.NamChanwoo {
    public class Right_Orc2_material : MonoBehaviour
    {
        public Material objectMaterial;
        public float Right_brightnessValue; // ���� ��ü�� ��ϰ�
        Test3Battle Test3BattleInstance;
        TutorialBattleSystem TutorialBattleSystem;
        int currentSceneIndex;
        private void Start()
        {
            // ���ο� Material �ν��Ͻ��� �����Ͽ� ���� ��ü�� Material�� �����մϴ�.
            Scene currentScene = SceneManager.GetActiveScene();
            currentSceneIndex = currentScene.buildIndex;
            Test3BattleInstance = FindObjectOfType<Test3Battle>();
            TutorialBattleSystem = FindObjectOfType<TutorialBattleSystem>();
            GetComponent<Renderer>().material = objectMaterial;
        }
        private void Update()
        {
            if (currentSceneIndex == 3)
            {
                if (Test3BattleInstance.selectEnemy == Test3BattleInstance.RightEnemy)
                {
                    Right_brightnessValue = 1.0f;
                }
                else
                {
                    Right_brightnessValue = 0.2f;
                }
            }
            else if (currentSceneIndex == 5)
            {
                if (TutorialBattleSystem.selectEnemy == TutorialBattleSystem.RightEnemy)
                {
                    Right_brightnessValue = 1.0f;
                }
                else
                {
                    Right_brightnessValue = 0.2f;
                }
            }
            
            objectMaterial.SetFloat("_Brightness", Right_brightnessValue);

        }
    }
}




