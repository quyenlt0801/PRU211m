using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDameForCreeps : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu vật thể va chạm là vật thể khác
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            TakeDame(100);
            Destroy(collision.gameObject);
        }
    }
    void TakeDame(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            ScoresManage.scoresCount += 10;
        }
    }
}
