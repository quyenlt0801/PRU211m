using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    private void Update()
    {
        float moveDistance = moveSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * moveDistance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu vật thể va chạm là vật thể khác
        if (collision.gameObject.CompareTag("Creeps"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
