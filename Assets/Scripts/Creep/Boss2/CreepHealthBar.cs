﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepHealthBar : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;

    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        CreepBar.Instance.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu vật thể va chạm là vật thể 
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            TakeDame(100);
            collision.gameObject.SetActive(false);
        }
    }

    async void TakeDame(int dame)
    {
        currentHealth -= dame;
        CreepBar.Instance.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
