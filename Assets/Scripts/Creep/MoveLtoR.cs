using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLtoR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển vật thể sang trái
        transform.Translate(Vector2.left * 2f * Time.deltaTime);
    }
}
