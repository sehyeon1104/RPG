using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    protected int level;
    [SerializeField]
    protected int hp;
    [SerializeField]
    protected int maxHp;
    [SerializeField]
    protected int attackPower;
    [SerializeField]
    protected int defense;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected int attack;
    public int Level { get=>level;set { level = value; } }
    public int HP { get=>hp;set { hp = value; } }
    public int Attack { get => attack;set { attack = value; } }
    public int MaxHp { get=>maxHp;set { maxHp = value; } }
    public int AttackPower { get=>attackPower;set { attackPower = value; } }
    public int Defense { get=>defense;set { defense = value; } }
    public float MoveSpeed { get => moveSpeed; set { moveSpeed = value; } }
    void Start()
    {
        attack = 10;
        level = 1;
        hp = 100;
        maxHp = 100;
        attackPower = 10;
        defense = 5;
        moveSpeed = 5f;
    }

    public virtual void OnAttacked(Stat attacker)
    {
        int damage = Mathf.Max(0, attacker.Attack - Defense);
        HP -= damage;
        if(HP<=0)
        {
            HP = 0;
            OnDead(attacker);
        }
    }

    protected virtual void OnDead(Stat attacker)
    {
        PlayerStat playerStat = attacker as PlayerStat;
        if(playerStat!=null)
        {
            playerStat.Exp += 15;
        }
    }

    void Update()
    {
        
    }
}
