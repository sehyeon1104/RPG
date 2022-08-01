using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance; //유일성 보장 내부 변수
    static Managers Instance { get { Init(); return instance; } }


    //메니저들 연결
    ResourceManager resource = new ResourceManager();
    GameManager game =new GameManager();
    DataManager data=new DataManager();
    //매니저들 프로퍼티
    public static ResourceManager Resorce { get { return Instance.resource; } }
    public static GameManager Game { get { return Instance.game; } }
    public static DataManager Data { get { return Instance.data; } }
    void Start()
    {
        //초기화
        Init();


    }

    // Update is called once per frame
    void Update()
    {
     // 매프레임 처리   
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

            //각 매니저의 초기화\
            instance.data.Init();
            
        }
    }
    public static void Clear()
    {

    }
}
