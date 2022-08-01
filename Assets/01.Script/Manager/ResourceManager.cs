using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    public T Load<T>(string path) where T: Object
    {
        if(typeof(T)==typeof(GameObject))
        {
            string name = path;
            int index=name.LastIndexOf('/');
            if(index>=0)
            {
                name = name.Substring(index + 1);
            }
        }
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string paht,Transform parent=null)
    {
        GameObject orginal = Load<GameObject>($"Prefabs/{paht}");
        if (orginal == null)
        {
            Debug.Log($"Failed to load prefab : {paht}");
            return null;
        }
        GameObject go = Object.Instantiate(orginal, parent);
        go.name = orginal.name;
        return go;

    }
    public void Destroy(GameObject go)
    {
        if (go == null)
            return;
        Object.Destroy(go);
    }
}
