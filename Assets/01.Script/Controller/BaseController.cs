using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
   public enum MonsterState
    {
        Die,
        Moving,
        Idle,
        Skill,
    }

    [SerializeField]
    protected Vector3 destPos;

    [SerializeField]
    protected MonsterState state = MonsterState.Idle;

    [SerializeField]
    protected GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
