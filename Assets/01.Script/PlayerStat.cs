using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    protected int exp;
    [SerializeField]
    protected int gold;

    public int Exp { get { return exp; } set { exp = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    void Start()
    {
        level = 1;
        hp = 100;
        maxHp = 100;
        attackPower = 100;
        defense = 5;
        moveSpeed = 10f;
        exp = 0;
        gold = 0;
    }

   protected virtual void OnDead(Stat attacker)
    {
        Debug.Log("Player Dead");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    void Update()
    {
        
    }
}
