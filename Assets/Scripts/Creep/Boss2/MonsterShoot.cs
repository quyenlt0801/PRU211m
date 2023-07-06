using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab ??n
    public float bulletSpeed = 10f; // T?c ?? ??n
    public int bulletCount = 36; // S? l??ng ??n
    public float bulletSpread = 10f; // G�c t?a ??n
    public float timeBetweenBursts = 2f; // Th?i gian ch? gi?a c�c ch�m ??n

    private float timeSinceLastBurst = 0f; // Th?i gian k? t? l?n b?n ch�m ??n cu?i c�ng

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
            ShootBullets(); // B?n ch�m ??n
            timeSinceLastBurst = 0f; // ??t l?i th?i gian
        }
    }

    private void ShootBullets()
    {
        float angleStep = 360f / bulletCount; // G�c b??c gi?a c�c vi�n ??n

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep; // G�c c?a vi�n ??n hi?n t?i

            // T?o m?t ??i t??ng ??n t? prefab
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // T�nh to�n h??ng v� v?n t?c c?a ??n
            Vector2 bulletDirection = Quaternion.Euler(0f, 0f, angle) * Vector2.up;
            Vector2 bulletVelocity = bulletDirection * bulletSpeed;

            // Thi?t l?p v?n t?c cho ??n
            bulletRigidbody.velocity = bulletVelocity;
        }
    }
}
