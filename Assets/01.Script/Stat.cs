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

    public int Level { get=>level;set { level = value; } }
    public int HP { get=>hp;set { hp = value; } }

    public int MaxHp { get=>maxHp;set { maxHp = value; } }
    public int AttackPower { get=>attackPower;set { attackPower = value; } }
    public int Defense { get=>defense;set { defense = value; } }
    public float MoveSpeed { get => moveSpeed; set { moveSpeed = value; } }
    void Start()
    {
        level = 1;
        hp = 100;
        maxHp = 100;
        attackPower = 10;
        defense = 5;
        moveSpeed = 5f;
    }


    void Update()
    {
        
    }
}
