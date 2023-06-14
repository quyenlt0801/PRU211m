using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public Transform anchorPoint; // Điểm neo
    public float rotationSpeed = 100f; // Tốc độ xoay

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tăng góc quay dựa trên tốc độ xoay và thời gian
        float rotationAngle = rotationSpeed * Time.deltaTime;

        // Sử dụng hàm transform.Rotate để xoay đối tượng
        transform.RotateAround(anchorPoint.position, Vector3.forward, rotationAngle);
    }
}
