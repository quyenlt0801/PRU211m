using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab đạn
    public float bulletSpeed = 10f; // Tốc độ đạn
    public int bulletCount = 36; // Số lượng đạn
    public float bulletSpread = 10f; // Góc tỏa đạn
    public float timeBetweenBursts = 2f; // Thời gian chờ giữa các chùm đạn

    private float timeSinceLastBurst = 0f; // Thời gian kể từ lần bắn chùm đạn cuối cùng

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
            ShootBullets(); // Bắn chùm đạn
            timeSinceLastBurst = 0f; // Đặt lại thời gian
        }
    }

    private void ShootBullets()
    {
        float angleStep = 360f / bulletCount; // Góc bước giữa các viên đạn

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep; // Góc của viên đạn hiện tại

            // Tạo một đối tượng đạn từ prefab
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            AudioManage audio_manager = AudioManage.GetAudio();
            audio_manager.ShootingCreeps();

            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Tính toán hướng và vận tốc của đạn
            Vector2 bulletDirection = Quaternion.Euler(0f, 0f, angle) * Vector2.up;
            Vector2 bulletVelocity = bulletDirection * bulletSpeed;

            // Thiết lập vận tốc cho đạn
            bulletRigidbody.velocity = bulletVelocity;
        }
    }
}
