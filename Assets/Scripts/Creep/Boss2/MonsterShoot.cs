using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab ??n
    public float bulletSpeed = 10f; // T?c ?? ??n
    public int bulletCount = 36; // S? l??ng ??n
    public float bulletSpread = 10f; // Góc t?a ??n
    public float timeBetweenBursts = 2f; // Th?i gian ch? gi?a các chùm ??n

    private float timeSinceLastBurst = 0f; // Th?i gian k? t? l?n b?n chùm ??n cu?i cùng

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastBurst += Time.deltaTime;

        if (timeSinceLastBurst >= timeBetweenBursts)
        {
            ShootBullets(); // B?n chùm ??n
            timeSinceLastBurst = 0f; // ??t l?i th?i gian
        }
    }

    private void ShootBullets()
    {
        float angleStep = 360f / bulletCount; // Góc b??c gi?a các viên ??n

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep; // Góc c?a viên ??n hi?n t?i

            // T?o m?t ??i t??ng ??n t? prefab
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Tính toán h??ng và v?n t?c c?a ??n
            Vector2 bulletDirection = Quaternion.Euler(0f, 0f, angle) * Vector2.up;
            Vector2 bulletVelocity = bulletDirection * bulletSpeed;

            // Thi?t l?p v?n t?c cho ??n
            bulletRigidbody.velocity = bulletVelocity;
        }
    }
}
