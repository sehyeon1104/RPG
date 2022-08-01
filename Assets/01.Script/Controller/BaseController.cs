using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
   public enum MonsterState
    {
        Die,
        Moving,
        Idle,
        Skill,
    }

    [SerializeField]
    protected Vector3 destPos; //목적지

    [SerializeField]
    protected MonsterState state = MonsterState.Idle; //몬스터 상태

    [SerializeField] 
    protected GameObject target; // 공격할 타겟

    public Define.MosterObject MosterObjectType { get; protected set; } = Define.MosterObject.Unknown;

    public virtual MonsterState State
    {
        get { return state; }
        set
        {
            state = value;

            Animator anim = GetComponent<Animator>();
            switch(state)
            {
                case MonsterState.Die:
                    break;
                    case MonsterState.Idle:
                    anim.CrossFade("WAIT", 0.1f);
                    break;
                case MonsterState.Moving:
                    anim.CrossFade("RUN", 0.1f);
                    break;
                case MonsterState.Skill:
                    anim.CrossFade("ATTACK", 0.1f, -1, 0);
                    break;  
            }
        }
    }
    void Start()
    {
        Init();
    }

    
   

    void Update()
    {
        switch(State)
        {
            case MonsterState.Die:
                UpdateDie();
                break;
            case MonsterState.Idle:
                UpdateIdle();
                break;
            case MonsterState.Moving:
                UpdateMoving();
                break;
            case MonsterState.Skill:
                UpdateSkill();
                break;
        }
            
    }

    protected virtual void UpdateSkill()
    {
       
    }

    protected virtual void UpdateMoving()
    {
        
    }

    protected virtual void UpdateIdle()
    {
        
    }

    protected virtual void UpdateDie()
    {
        
    }

    public abstract void Init();

}
