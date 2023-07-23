using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDameForCreeps : MonoBehaviour
{

    public GameObject bloodPrefab; // Prefab cho đối tượng máu

    public int maxHealth = 100;
    public int currentHealth;

    public GameObject Explosion;
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
            Instantiate(Explosion, transform.position, Quaternion.identity);
            TakeDame(100);
            collision.gameObject.SetActive(false);
        }
    }
    void TakeDame(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            int randomValue = Random.Range(0, 10);
            Debug.Log("Random.value :" + randomValue);
            if (randomValue == 0)
            {
                // Tạo một đối tượng máu và đặt vị trí là vị trí của quái
                Instantiate(bloodPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
