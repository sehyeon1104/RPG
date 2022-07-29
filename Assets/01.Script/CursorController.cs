using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    Texture2D attackIcon;
    [SerializeField]
    Texture2D handIcon;

    //  ���̾ ���� �̰ų� �׶��� �� �� ����ũ ó��
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
