using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoderDestrCr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu vật thể va chạm là vật thể khác
        if (collision.gameObject.CompareTag("Creeps"))
        {
            collision.gameObject.SetActive(false);
        }
    }

}
