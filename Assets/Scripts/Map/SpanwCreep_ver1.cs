using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwCreep_ver1 : MonoBehaviour
{
    public List<GameObject> monsterPrefabs; // Danh sách Prefabs quái vật
    public List<GameObject> bossPrefabs; // Danh sách Prefabs boss

    public GameObject pointSpawnBoss;
    public GameObject boss1;
    public GameObject boss2;

    public GameObject spawnlv1;
    public GameObject spawnlv2;
    public GameObject spawnlv3;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    public float timeBetWeenSpawn;
    private float timeSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeSpawn)
        {
            Spawns();
            timeSpawn = Time.time + timeBetWeenSpawn;
        }
    }

    public void Spawns()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        if (GetScores() >= 0 && GetScores() < 100)
        {
            Instantiate(spawnlv1, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        }
        else if (GetScores() >= 100 && GetScores() < 200)
        {
            Instantiate(spawnlv2, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        }
        else if (GetScores() >= 200)
        {
            int randomIndex = Random.Range(0, monsterPrefabs.Count);
            GameObject randomMonsterPrefab = monsterPrefabs[randomIndex];
            Instantiate(randomMonsterPrefab, transform.position + new Vector3(randomX, randomY, 0), Quaternion.identity);
        }
        if (GetScores() > 0 && GetScores() % 300 == 0)
        {
            int Index = Random.Range(0, bossPrefabs.Count);
            GameObject bossPrefab = bossPrefabs[Index];
            Instantiate(bossPrefab, transform.position, Quaternion.identity);
            Debug.Log("abc :" + Index);
        }
    }

    private static float GetScores()
    {
        Debug.Log((int)ScoresManage.scoresCount);

        return (int)ScoresManage.scoresCount;

    }
}
