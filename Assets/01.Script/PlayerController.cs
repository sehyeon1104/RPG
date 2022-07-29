using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public enum PlayerState
    {
        Die,
        Moving,
        Idle,
        Skill
    }
    [SerializeField]
    PlayerState state = PlayerState.Idle;

    float moveSpeed = 10f;
    Vector3 destPos;

    public PlayerState State
    {
        get => state;
        set
        {
            state = value;
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
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
       
    }

    private void UpdateMoving()
    {
        Vector3 dir = destPos - transform.position;
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

            float moveDDist = Mathf.Clamp(moveSpeed*Time.deltaTime,0,dir.magnitude);
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

                break;
            case PlayerState.Moving:
                OnMouseEvent_IdleMoving();
                break;
            case PlayerState.Skill:

                break;
            case PlayerState.Die:
                break;
        }
    }
    void OnMouseEvent_IdleMoving()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool raycastHit = Physics.Raycast(ray, out hit,100f,LayerMask.GetMask("Ground"));

        if(Input.GetMouseButtonDown(0))
        {
            if(raycastHit)
            {
                destPos = hit.point;
                state = PlayerState.Moving;
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(raycastHit)
            {
                destPos=hit.point;
            }
        if(Input.GetMouseButtonUp(0))
        {

        }
        }
    }
}
