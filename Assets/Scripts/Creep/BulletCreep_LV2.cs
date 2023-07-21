using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreep_LV2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;

    private float nextFireTime;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 2f / fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioManage audio_manager = AudioManage.GetAudio();
        audio_manager.ShootingCreeps();
    }
}
