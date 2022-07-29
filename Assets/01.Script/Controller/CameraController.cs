using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode mode = Define.CameraMode.Quaterview;

    [SerializeField]
    Vector3 delta = new Vector3(0.0f, 6, -5);

    [SerializeField]
    GameObject player = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        
        if(mode == Define.CameraMode.Quaterview)
        {
            RaycastHit hit;
            Vector3 playerPos =player.transform.position+Vector3.up*0.8f;
            if(Physics.Raycast(playerPos,delta,out hit,delta.magnitude,LayerMask.GetMask("Block")))
                {
                float dist = (hit.point - playerPos).magnitude * 0.8f;
                transform.position =playerPos+delta.normalized*dist;
            }
            else
            {

            transform.position = player.transform.position + delta;
            transform.LookAt(player.transform);
            }
        }
    }
    
    public void SetQuartView(Vector3 pos)
    {
        mode =Define.CameraMode.Quaterview;
        delta = pos;
    }
}
