using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterController : BaseController
{
    Stat stat;
    NavMeshAgent agent;

    [SerializeField]
    float scanRange = 10f;

    [SerializeField]
    float attackRange = 2f;

    [SerializeField]
    GameObject player = null;

    public override void Init()
    {
        MosterObjectType = Define.MosterObject.Knight;
        stat =gameObject.GetComponent<Stat>();
        agent=gameObject.GetComponent<NavMeshAgent>();
        if(player==null)
        {
            player = GameObject.Find("Player");
        }
    }
    protected override void UpdateIdle()
    {
        if(player==null)
        {
            return;
        }

        float distance = (player.transform.position - transform.position).magnitude;
        if(distance <=scanRange)
        {
            target = player;
            State = MonsterState.Moving;
            return;
        }
    }
    protected override void UpdateDie()
    {
      
    }
    protected override void UpdateMoving()
    {
        //타겟이 내 공격 사정거리보다 가까우면 
        if (target != null)
        {
            destPos = target.transform.position;
            float distance = (destPos - transform.position).magnitude;
            if(distance <= attackRange)
            {
                if (agent != null)
                    agent.SetDestination(transform.position);

                State = MonsterState.Skill;
                return;
            }
        }
        Vector3 dir = destPos - transform.position;
        if(dir.magnitude<0.1f)
        {
            State = MonsterState.Idle;
        }
        else
        {
            if (agent == null)
                return;

            agent.SetDestination(destPos);
            agent.speed = stat.MoveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        
    }
    protected override void UpdateSkill()
    {
        if(target!=null)
        {
            Vector3 dir = target.transform.position - transform.position;
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),20*Time.deltaTime);
        }
        base.UpdateSkill();
    }
}
