using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HearlthBar hearlthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hearlthBar.SetMaxHealth(maxHealth);
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
            Destroy(collision.gameObject);
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
