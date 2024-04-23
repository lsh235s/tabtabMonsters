using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialBase : MonoBehaviour
{
    // abstract : �߻�Ŭ���� -> �ڽ�Ŭ�������� �ݵ�� �����ǰ� �ʿ���
    // Ʃ�丮���� �����Ҷ� 1ȸ ȣ��
    public abstract void Enter();
    // Ʃ�丮���� �����ϴ� ���� �� �����Ӵ� ȣ��
    public abstract void Execute(TurorialControll controll);
    // Ʃ�丮���� �����Ҷ� 1ȸ ȣ��
    public abstract void Exit();

}
