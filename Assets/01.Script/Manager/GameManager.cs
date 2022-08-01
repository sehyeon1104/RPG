using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager
{
   HashSet<GameObject> monsters =new HashSet<GameObject>();

    public Action<int> OnSpawnEvent;

    public GameObject Spawn(Define.MosterObject type ,string path,Transform parent=null)
    {
        GameObject go = Managers.Resorce.Instantiate(path, parent);
        switch(type)
        {
            case Define.MosterObject.Knight:
                monsters.Add(go);
                if (OnSpawnEvent != null)
                    OnSpawnEvent.Invoke(1);
                break;
        }

        return go;
    }
    public void DeSpawn(GameObject go)
    {
        Define.MosterObject type = Define.MosterObject.Unknown;
        BaseController bc=go.GetComponent<BaseController>();
        if (bc != null)
            type = bc.MosterObjectType;

        switch(type)
        {
            case Define.MosterObject.Knight:
                if (monsters.Contains(go))
                {   
                    monsters.Remove(go);
                    if (OnSpawnEvent != null)
                        OnSpawnEvent.Invoke(-1);
                }
                break;  
        }
        Managers.Resorce.Destroy(go);

        
    }
}
