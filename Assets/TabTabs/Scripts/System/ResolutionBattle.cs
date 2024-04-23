using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionBattle : MonoBehaviour
{
    // 1. ����� �ػ󵵰� ����ȭ�麸�� "����" ���
    //- ����ȭ���� �ʺ�(W)�� �����ؾ� �ϰ� X�� ���� ����Ǿ���Ѵ�. 
    //- 1920x1080�� �ػ� ������ 200x100�ػ� ��⿡ �����Ѵٸ�
    //- X = [1-{(1920/1080)}/(200/100)}] / 2
    //- Y = 0 // �������� ����
    //- W = (1920/1080)/(200/100)
    //- H = 1 // ��������

    // 2. ����� �ػ󵵰� ����ȭ�麸�� �� "����"���
    //- ����ȭ���� ���̰� �����ؾ� �ϸ� Y�� ���� ����Ǿ�� �Ѵ�.
    //- X = 0 // �������� ����
    //- Y = [1-{(100/200)/(1920/1080)}] /2
    //- W = 1 // ����ȭ���� �ʺ�� ����
    //- H = (100/200)/(1920/1080)

    private void Awake()
    {
        SetResolutionBattle(540, 860);
    }

    void SetResolutionBattle(int width = 540, int height = 860)
    {

        int deviceWidth = Screen.width; // ����� �ػ� �ʺ�
        int deviceHeight = Screen.height; // ����� �ػ� ����

        Screen.SetResolution(width, (int)(((float)deviceHeight / deviceWidth) * width), true);
        // �ػ� ����

        if ((float)width / height < (float)deviceWidth / deviceHeight)
        {// ���� ����� �ػ󵵺� �� ũ�ٸ�
            float newWidth = ((float)width / height) / ((float)deviceWidth / deviceHeight);
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
            // ����ī�޶��� ViewPortRect�� ����
            // Rect : X, Y, W, H ��
        }
        else
        {// ����ȭ���� �ػ󵵺� �� ũ�ٸ�
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)width / height);
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
        }
    }
}
