using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private GameObject player; // Reference to the player's Transform component
    public float speed = 5f; // The speed at which the object moves

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("gun");
    }
    private void Update()
    {
        // Calculate the direction towards the player
        Vector2 direction = player.transform.position - transform.position;

        // Normalize the direction vector to get a unit direction
        direction.Normalize();

        // Move the object towards the player
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
