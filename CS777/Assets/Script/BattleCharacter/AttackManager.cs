using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public static AttackManager attackManager;
    private string attackDatafilePath;
    public static AttackManager Instance
    {
        get
        {
            if (attackManager == null)
            {
                attackManager = FindObjectOfType<AttackManager>();
                if (attackManager == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(AttackManager).Name;
                    attackManager = go.AddComponent<AttackManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return attackManager;
        }
    }
    void Awake()
    {
        if (attackManager == null)
        {
            attackManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void NextBreak()
    {

    }





}
