using Assets.Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;
    private float moveSpeed;

    public float shootCooldown = 1f; // Thời gian chờ giữa các lần bắn
    private float shootTimer = 0f; // Thời gian đã trôi qua từ lần bắn trước đó
    private bool canShoot = true; // Cho phép bắn hay không

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }
    private void Update()
    {
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootCooldown)
            {
                canShoot = true;
            }
        }
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * moveSpeed;
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.up * -moveSpeed;
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
    public void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            AudioManage audio_manager = AudioManage.GetAudio();
            audio_manager.ShootingPlayer();
            shootTimer = 0f;
            canShoot = false;
        }
    }
}
