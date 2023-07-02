using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwCreep_ver1 : MonoBehaviour
{
    public List<GameObject> monsterPrefabs; // Danh sách Prefabs quái vật

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
        if (ScoresManage.scoresCount >= 0 && ScoresManage.scoresCount < 100)
        {
            Instantiate(spawnlv1, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        }else if (ScoresManage.scoresCount >= 100 && ScoresManage.scoresCount < 200)
        {
            Instantiate(spawnlv2, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        }else if (ScoresManage.scoresCount >= 200 && ScoresManage.scoresCount < 300)
        {
            Instantiate(spawnlv3, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        else if (ScoresManage.scoresCount >= 300)
        {
            int randomIndex = Random.Range(0, monsterPrefabs.Count);
            GameObject randomMonsterPrefab = monsterPrefabs[randomIndex];

            Instantiate(randomMonsterPrefab, transform.position + new Vector3(randomX, randomY, 0), Quaternion.identity);
        }
    }
}
