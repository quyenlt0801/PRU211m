using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwCreep_ver1 : MonoBehaviour
{
    public GameObject spawn;
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
        Instantiate(spawn, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
