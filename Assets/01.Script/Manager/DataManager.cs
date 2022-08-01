using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[serializable]

public class StatData
{
    public int level;
    public int maxHp;
    public int attack;
    public int totalExp;
}
public interface ILoader<Key,Value>
{
    Dictionary<Key, Value> MakeDict();
}
[serializable]
public class StatList : ILoader<int , StatData>
{
    public List<StatData> stats = new List<StatData> ();
  
    public Dictionary<int, StatData> MakeDict()
    {
        Dictionary<int, StatData> dict = new Dictionary<int, StatData>();
        foreach (StatData stat in stats)
        {
            dict.Add(stat.level, stat);
        }
        return dict;
    }
}
public class DataManager
{
    public Dictionary<int, StatData> StatDict { get; private set; } = new Dictionary<int, StatData>();

    public void Init()
    {
        StatDict = LoadJson<StatList, int, StatData>("StatData").MakeDict();
    }
    Loader LoadJson<Loader, key, value>(string path) where Loader : ILoader<key, value>
    {
        TextAsset textAsset = Managers.Resorce.Load<TextAsset>($"Data/{path} ");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
