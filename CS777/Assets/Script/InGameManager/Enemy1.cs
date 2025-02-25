using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy1 : InGameEnemy
{
    // 생성자: 부모 클래스의 생성자를 호출
    public Enemy1(string name, int hp) : base(name, hp)
    {
        // Enemy1 초기화 (필요하면 추가 작업 가능)
    }

    // 패턴 1: 공격하고 방어력을 증가시킴
    public override void pattern1()
    {
        Debug.Log($"{enemyName} uses pattern1!");

        if (ingp != null) // InGamePlayer가 연결되어 있는지 확인
        {
            attack(30);       // 플레이어에게 30의 공격
            robustChange(30); // 방어력 30 증가
        }
        else
        {
            Debug.Log("No target player (ingp is null).");
        }
    }

    // 패턴 2: 아직 구현되지 않음
    public override void pattern2()
    {
        Debug.Log($"{enemyName} uses pattern2, but it's not implemented.");
    }
}