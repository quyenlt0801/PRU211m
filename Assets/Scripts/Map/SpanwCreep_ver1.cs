using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwCreep_ver1 : MonoBehaviour
{
    public List<GameObject> spawnlv1Pool;
    public List<GameObject> spawnlv2Pool;
    public List<GameObject> spawnlv3Pool;
    private Dictionary<GameObject, List<GameObject>> monsterPools;

    public int poolSize = 5; // Kích thước của Pool (số lượng đối tượng trong Pool)
    private GameObject Player;

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
        monsterPools = new Dictionary<GameObject, List<GameObject>>();

        // Khởi tạo Pool cho từng loại đối tượng
        spawnlv1Pool = ObjectPool.Instance.InitializePool(spawnlv1, poolSize);
        spawnlv2Pool = ObjectPool.Instance.InitializePool(spawnlv2, poolSize);
        spawnlv3Pool = ObjectPool.Instance.InitializePool(spawnlv3, poolSize);

        foreach (GameObject monsterPrefab in monsterPrefabs)
        {
            // Khởi tạo Pool cho từng loại quái trong monsterPrefabs
            List<GameObject> objectPool = ObjectPool.Instance.InitializePool(monsterPrefab, poolSize);
            monsterPools.Add(monsterPrefab, objectPool);
        }

        Player = GameObject.FindGameObjectWithTag("Player");
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
            // Sử dụng đối tượng từ Pool spawnlv1Pool
            GameObject spawnlv1Obj = ObjectPool.Instance.GetObjectFromPool(spawnlv1Pool);
            spawnlv1Obj.transform.position = transform.position + new Vector3(randomX, randomY, 0);
            spawnlv1Obj.SetActive(true);
        }
        else if (GetScores() >= 100 && GetScores() < 200)
        {
            // Sử dụng đối tượng từ Pool spawnlv2Pool
            GameObject spawnlv2Obj = ObjectPool.Instance.GetObjectFromPool(spawnlv2Pool);
            spawnlv2Obj.transform.position = transform.position + new Vector3(randomX, Player.transform.position.y, 0);
            spawnlv2Obj.SetActive(true);
        }
        else if (GetScores() >= 200)
        {
            int randomIndex = Random.Range(0, monsterPrefabs.Count);
            GameObject randomMonsterPrefab = monsterPrefabs[randomIndex];
            GameObject monsterObj = ObjectPool.Instance.GetObjectFromPool(monsterPools[randomMonsterPrefab]);
            monsterObj.transform.position = transform.position + new Vector3(randomX, randomY, 0);
            monsterObj.SetActive(true);
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
