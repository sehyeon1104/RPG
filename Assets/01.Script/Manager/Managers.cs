using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance; //���ϼ� ���� ���� ����
    static Managers Instance { get { Init(); return instance; } }


    //�޴����� ����
    ResourceManager resource = new ResourceManager();
    GameManager game =new GameManager();
    DataManager data=new DataManager();
    //�Ŵ����� ������Ƽ
    public static ResourceManager Resorce { get { return Instance.resource; } }
    public static GameManager Game { get { return Instance.game; } }
    public static DataManager Data { get { return Instance.data; } }
    void Start()
    {
        //�ʱ�ȭ
        Init();


    }

    // Update is called once per frame
    void Update()
    {
     // �������� ó��   
    }
    static void Init()
    {
        if(instance == null)
        {
            
            GameObject go = GameObject.Find("@Manager");
                if(go != null)
                {
                    go = new GameObject { name = "@Manager" };
                    go.AddComponent<Managers>();
                }


                instance=go.GetComponent<Managers>();

            //�� �Ŵ����� �ʱ�ȭ\
            instance.data.Init();
            
        }
    }
    public static void Clear()
    {

    }
}
