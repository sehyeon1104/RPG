using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIIHpBar : MonoBehaviour
{
    Stat stat;
    void Start()
    {
        stat =transform.parent.GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {   
        Transform parent = transform.parent;
        transform.position = parent.position + Vector3.up * parent.GetComponent<Collider>().bounds.size.y;
        transform.rotation =Camera.main.transform.rotation;
        float ratio = stat.HP / (float)stat.MaxHp;
        gameObject.GetComponentInChildren<Slider>().value = ratio;
    }
}
