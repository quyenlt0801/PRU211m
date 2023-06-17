using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCreep : MonoBehaviour
{
    private float delay = 2f;

    public Transform spawnPoint1; // Điểm chấm sẵn trên màn hình
    public Transform spawnPoint2; // Điểm chấm sẵn trên màn hình
    public Transform spawnPoint3; // Điểm chấm sẵn trên màn hình

    [SerializeField]
    public GameObject bullet; // Prefab bullet

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet", delay, delay);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnBullet()
    {
        GameObject bulletCreep = Instantiate(bullet, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
        GameObject bulletCreep2 = Instantiate(bullet, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
        GameObject bulletCreep3 = Instantiate(bullet, spawnPoint3.transform.position, spawnPoint3.transform.rotation);
        
        Rigidbody2D bulletCreep_body = bulletCreep.GetComponent<Rigidbody2D>();
        Rigidbody2D bulletCreep_body2 = bulletCreep2.GetComponent<Rigidbody2D>();
        Rigidbody2D bulletCreep_body3 = bulletCreep3.GetComponent<Rigidbody2D>();

        bulletCreep_body.AddForce(GetBulletDirection(spawnPoint1) * 15f, ForceMode2D.Impulse);
        bulletCreep_body2.AddForce(GetBulletDirection(spawnPoint2) * 15f, ForceMode2D.Impulse);
        bulletCreep_body3.AddForce(GetBulletDirection(spawnPoint3) * 15f, ForceMode2D.Impulse);

     



        Destroy(bulletCreep, 3f);
        Destroy(bulletCreep2, 3f);
        Destroy(bulletCreep3, 3f);
    }
    Vector2 GetBulletDirection(Transform vertexPoint)
    {
        Vector2 bulletDirection = vertexPoint.position - transform.position;
        bulletDirection.Normalize();
        return bulletDirection;
    }
}
