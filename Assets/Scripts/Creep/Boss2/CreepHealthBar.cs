using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepHealthBar : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;

    public HearlthBar hearlthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hearlthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu vật thể va chạm là vật thể khác
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            TakeDame(100);
            collision.gameObject.SetActive(false);
        }
    }

    async void TakeDame(int dame)
    {
        currentHealth -= dame;
        hearlthBar.SetHealth((int)currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
