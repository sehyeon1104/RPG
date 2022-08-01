using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool raycastHit;
   public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Skill
    }
    [SerializeField]
    PlayerState state = PlayerState.Idle;

    PlayerStat stat;
    Vector3 destPos;

    int layerMask = ((1 << (int)Define.Layer.Monster) | (1 << (int)Define.Layer.Ground));

    //°ø°ÝÇÏ´Â Å¸°Ù
    GameObject lockTarget;
//
    bool stopSkill = false;
    public PlayerState State
    {
        get => state;
        set
        {
            state = value;
            Animator anim = GetComponent<Animator>();
            switch(State)
            {
                case PlayerState.Die:
                    break;
                    case PlayerState.Idle:
                    anim.CrossFade("WAIT", 0.1f);
                    break;
                case PlayerState.Moving:
                    anim.CrossFade("RUN", 0.1f);
                    break;
                    case PlayerState.Skill:
                    anim.CrossFade("ATTACK", 0.1f, -1, 0);
                    break;


            }
        }
    }
    private void Start()
    {
        stat = GetComponent<PlayerStat>();
    }
    private void Update()
    {
        print(stopSkill);
        OnMouseEvent();

        switch (State)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Skill:
                UpdateSkill();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;  
        }
    }

    private void UpdateDie()
    {
    
    }

    private void UpdateSkill()
    {
        if (lockTarget != null)
        {
            Vector3 dir =lockTarget.transform.position-transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, quat, 20f * Time.deltaTime);
        }
    }

    private void UpdateMoving()
    {

        if(lockTarget != null)
        {
            destPos = lockTarget.transform.position;
            float distance = (destPos - transform.position).magnitude;
            if (distance <= 1f)
            {
                State = PlayerState.Skill;
                return;
            }
        }
        Vector3 dir = destPos - transform.position;
        dir.y = 0;
        if(dir.sqrMagnitude<0.1f*0.1f)
        {
            State = PlayerState.Idle;
        }    
        else
        {
            //Block Raycast·Î ¸ØÃß±â
            Debug.DrawRay(transform.position + Vector3.up * 0.5f, dir.normalized, Color.green);
            if(Physics.Raycast(transform.position+Vector3.up*0.5f,dir,1f,LayerMask.GetMask("Block")))
                {
                if(!Input.GetMouseButton(0))
                {
                    State = PlayerState.Idle;
                }
                return;
            }

            float moveDDist = Mathf.Clamp(4f*Time.deltaTime,0,dir.magnitude);
            transform.position += dir.normalized * moveDDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }

    private void UpdateIdle()
    {
        
    }

    private void OnMouseEvent()
    {
      switch(State)
        {
            case PlayerState.Idle:
                OnMouseEvent_IdleMoving();
                break;
            case PlayerState.Moving:
                OnMouseEvent_IdleMoving();
                break;
            case PlayerState.Skill:
                OnMouseEvent_IdleMoving();
                break;
            case PlayerState.Die:
                break;
        }
    }
    void OnMouseEvent_IdleMoving()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         raycastHit = Physics.Raycast(ray, out hit,100f,layerMask);

        if(Input.GetMouseButtonDown(0))
        {
            if(raycastHit)
            {
                destPos = hit.point;
                State = PlayerState.Moving;
                stopSkill = false;
                if (hit.collider.gameObject.layer == (int)Define.Layer.Monster)
                    lockTarget = hit.collider.gameObject;
                else
                    lockTarget = null;
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(lockTarget ==null&& raycastHit)
            {
                destPos=hit.point;
            }
        if(Input.GetMouseButtonUp(0))
        {
                stopSkill = true;
        }
        }
    }
    public void OnHitEvent()
    {
       if(stopSkill)
        {
            State = PlayerState.Idle;
            
        }
        else
        {
            State = PlayerState.Skill;
        }
    }
}
