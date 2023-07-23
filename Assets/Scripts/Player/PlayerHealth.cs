using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerData();
        if (currentHealth <= 0)
        {
            // If the player's health is zero or negative after loading, reset it to max health
            currentHealth = maxHealth;
        }
        HearlthBar.Instance.SetMaxHealth(maxHealth);
        HearlthBar.Instance.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDame(20);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu vật thể va chạm là vật thể khác
        if (collision.gameObject.CompareTag("Creeps"))
        {
            TakeDame(20);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Blood"))
        {
            IncreaseHealth(20);
            Destroy(collision.gameObject);
        }
    }
    private void LoadPlayerData()
    {
        // Load player's current health from PlayerPrefs
        currentHealth = PlayerPrefs.GetInt("PlayerCurrentHealth", maxHealth);
    }
    private void OnDestroy()
    {
        // Save player's current health when the game object is destroyed (e.g., when the scene changes)
        SavePlayerData();
    }
    private void SavePlayerData()
    {
        // Save player's current health to PlayerPrefs
        PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);

        // Save PlayerPrefs data
        PlayerPrefs.Save();
    }

    async void TakeDame(int dame)
    {
        currentHealth -= dame;
        HearlthBar.Instance.SetHealth((int)currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        HearlthBar.Instance.SetHealth(currentHealth);
    }
}
