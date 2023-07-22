using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBarHealth : MonoBehaviour
{
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        bar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss") != null)
        {
            bar.SetActive(true);
        }
        else
        {
            bar.SetActive(false);
        }
    }
}
