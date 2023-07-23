using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepFlowPlayer : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField]
    private GameObject Player;
    public GameObject bulletPrefab;
    public List<GameObject> bulletPrefabPool;
    public int poolSize = 5; // Kích thước của Pool (số lượng đối tượng trong Pool)

    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    private float nextFireTime;

    private void Start()
    {
        bulletPrefabPool = ObjectPool.Instance.InitializePool(bulletPrefab, poolSize);
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        
        // Bắn đạn theo tần suất fireRate
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            GameObject bullet = ObjectPool.Instance.GetObjectFromPool(bulletPrefabPool);
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);

            AudioManage audio_manager = AudioManage.GetAudio();
            audio_manager.ShootingCreeps();
            bullet.GetComponent<BulletFlow>().Target = Player.transform.position;
        }
    }
    
}
