using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    protected int exp;
    [SerializeField]
    protected int gold;

    public int Exp {
        get { return exp; }
        set {
            exp = value;
            int level = 1;
            while(true)
            {
                StatData stat;
                if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
                    break;
                if (exp < stat.totalExp)
                    break;

                level++;

            }
            if(level !=Level)
            {
                print("Level Up!");
                Level = level;
                SetStat(Level);
            }
        
        }
    }

    public int Gold { get { return gold; } set { gold = value; } }
    void Start()
    {   
        level = 1;
        defense = 5;
        moveSpeed = 10f;
       
        gold = 0;
    }
    public void SetStat(int _level)
    {
        {
            Dictionary<int, StatData> dict = Managers.Data.StatDict;
            StatData stat = dict[_level];
            HP = stat.maxHp;
            maxHp = stat.maxHp;
            Attack=stat.attack;
        } }
   public virtual void OnDead(Stat attacker)
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
