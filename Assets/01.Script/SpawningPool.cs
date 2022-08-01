using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawningPool : MonoBehaviour
{
    [SerializeField]
    int monsterCount = 0; // 생성된 몬스터 수

    int reserveCount = 0; // 생성중인 몬스터 수

    [SerializeField]
    int keepMonsterCount = 0; // 맵에 유지하고자 하는 몬스터 수

    [SerializeField]
    Vector3 spawnPos;
    [SerializeField]
    float spawnRadius = 15f;
    [SerializeField]
    float spawnTime = 5.0f;

    public void AddMonsterCount(int value) { monsterCount+=value; }
    public void SetKeepMonsterCount(int count) { keepMonsterCount = count; }
    void Start()
    {
        Managers.Game.OnSpawnEvent -= AddMonsterCount;
        Managers.Game.OnSpawnEvent += AddMonsterCount;
    }

    // Update is called once per frame
    void Update()
    {
        while(monsterCount+reserveCount<keepMonsterCount)
        {
            StartCoroutine(ReserveSpawn());
        }
    }
    IEnumerator ReserveSpawn()
    {
        reserveCount++;
        yield return new WaitForSeconds(Random.Range(1f,spawnTime));

        GameObject obj = Managers.Game.Spawn(Define.MosterObject.Knight, "Knight");
        NavMeshAgent agent = obj.GetComponent<NavMeshAgent>();

        Vector3 randPos;
        while(true)
        {
            Vector3 randDir =Random.insideUnitSphere*Random.Range(0f,spawnRadius);
            randDir.y = 0;
            randPos = spawnPos + randDir;

            NavMeshPath path = new NavMeshPath();

            if (agent.CalculatePath(randPos, path))
                break;
        }
        obj.transform.position = randPos;
        reserveCount--;
    }
}
