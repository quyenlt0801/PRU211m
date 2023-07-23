using Assets.Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    [SerializeField]
    public GameObject bulletPrefab;
    public int poolSize = 5;

    private List<GameObject> bullets;

    private Rigidbody2D rb;
    private float moveSpeed;

    public float shootCooldown = 1f; // Thời gian chờ giữa các lần bắn
    private float shootTimer = 0f; // Thời gian đã trôi qua từ lần bắn trước đó
    private bool canShoot = true; // Cho phép bắn hay không

    private int currentBulletIndex = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerPosX") || !PlayerPrefs.HasKey("PlayerPosY"))
        {
            Vector3 initialPosition = new Vector3(-9.48f, 0f, 0f);
            transform.position = initialPosition;
        }

        bullets = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
        Debug.Log("Count" + bullets.Count);
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        LoadPlayerData();
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
        SavePlayerData();
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
            GameObject bullet = GetBullet();
            Debug.Log(bullet);
            if (bullet != null)
            {
                bullet.transform.position = bulletSpawnPoint.position;
                bullet.transform.rotation = Quaternion.identity;

                bullet.SetActive(true);

                currentBulletIndex++;

                if (currentBulletIndex >= poolSize)
                {
                    currentBulletIndex = 0;
                }

                AudioManage audio_manager = AudioManage.GetAudio();
                audio_manager.ShootingPlayer();
                shootTimer = 0f;
                canShoot = false;
            }
        }
    }
    public GameObject GetBullet()
    {
        GameObject bullet = bullets[currentBulletIndex];

        if (bullet.activeInHierarchy)
        {
            bullet.SetActive(false);
        }

        return bullet;
    }
    private void LoadPlayerData()
    {
        // Load player position
        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX", -9.48f);
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY", 0f);
        Vector3 playerPosition = new Vector3(playerPosX, playerPosY, 0f);
        transform.position = playerPosition;

        // Load shoot timer
        shootTimer = PlayerPrefs.GetFloat("ShootTimer", 0f);
    }

    private void SavePlayerData()
    {
        // Save player position
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);

        // Save shoot timer
        PlayerPrefs.SetFloat("ShootTimer", shootTimer);

        // Save PlayerPrefs data
        PlayerPrefs.Save();
    }
}