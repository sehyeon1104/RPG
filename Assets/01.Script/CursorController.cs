using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    Texture2D attackIcon;
    [SerializeField]
    Texture2D handIcon;

    //  레이어가 몬스터 이거나 그라운드 일 때 마스크 처리
    int layerMask = (1<<(int)Define.Layer.Monster)|(1<<(int)Define.Layer.Ground);

    enum CursorType
    {
        None,
        Attack,
        Hand
    }

    CursorType cursorType =CursorType.None;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            return;
        }

        RaycastHit hit;
        Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition); 

        if(Physics.Raycast(ray,out hit,100f,layerMask))
        {
            if(hit.collider.gameObject.layer==(int )Define.Layer.Monster)
            {
                    if(cursorType!=CursorType.Attack)
                {
                    Cursor.SetCursor(attackIcon, new Vector2(attackIcon.width / 5,0), CursorMode.Auto);
                    cursorType = CursorType.Attack;



                }    
            }
            else
            {
                if(cursorType!=CursorType.Hand)
                {
                    Cursor.SetCursor(handIcon, new Vector2(handIcon.width / 3, 0), CursorMode.Auto);
                    cursorType = CursorType.Hand;
                }
            }
        }
    }
}
