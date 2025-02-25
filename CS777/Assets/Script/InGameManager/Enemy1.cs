using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy1 : InGameEnemy
{
    // ������: �θ� Ŭ������ �����ڸ� ȣ��
    public Enemy1(string name, int hp) : base(name, hp)
    {
        // Enemy1 �ʱ�ȭ (�ʿ��ϸ� �߰� �۾� ����)
    }

    // ���� 1: �����ϰ� ������ ������Ŵ
    public override void pattern1()
    {
        Debug.Log($"{enemyName} uses pattern1!");

        if (ingp != null) // InGamePlayer�� ����Ǿ� �ִ��� Ȯ��
        {
            attack(30);       // �÷��̾�� 30�� ����
            robustChange(30); // ���� 30 ����
        }
        else
        {
            Debug.Log("No target player (ingp is null).");
        }
    }

    // ���� 2: ���� �������� ����
    public override void pattern2()
    {
        Debug.Log($"{enemyName} uses pattern2, but it's not implemented.");
    }
}