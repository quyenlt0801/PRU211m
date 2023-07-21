using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepFlowPlayer : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField]
    private GameObject Player;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    private float nextFireTime;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        
        // Bắn đạn theo tần suất fireRate
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            AudioManage audio_manager = AudioManage.GetAudio();
            audio_manager.ShootingCreeps();
            bullet.GetComponent<BulletFlow>().Target = Player.transform.position;
        }
    }
    
}
