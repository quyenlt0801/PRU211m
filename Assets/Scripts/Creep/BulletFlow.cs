using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlow : MonoBehaviour
{
    public Vector3 Target;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    private void Update()
    {
        transform.Translate((transform.position - Target) * moveSpeed * Time.deltaTime * -1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu vật thể va chạm là vật thể khác
        if (collision.gameObject.CompareTag("Tuong"))
        {
            Destroy(gameObject);
        }
    }
}
