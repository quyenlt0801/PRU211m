using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLtoR : MonoBehaviour
{

    public float initialSpeed = 3f; // Tốc độ ban đầu
    private float currentSpeed; // Tốc độ hiện tại
    private int currentLevel = 1; // Cấp độ hiện tại của tốc độ

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoresManage.scoresCount >= 100 && ScoresManage.scoresCount < 200)
        {
            currentLevel = 2;
        }else if (ScoresManage.scoresCount > 200)
        {
            currentLevel = 3;
        }


        if (ScoresManage.scoresCount > 0 && currentLevel == 1)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
        else if (ScoresManage.scoresCount >= 100 && currentLevel == 2)
        {
            transform.Translate(Vector2.left * (currentSpeed + 2) * Time.deltaTime);
        }
        else if (ScoresManage.scoresCount >= 200 && currentLevel == 3)
        {
            transform.Translate(Vector2.left * (currentSpeed + 5) * Time.deltaTime);
        }
    }

    // Hàm này sẽ được gọi mỗi khi điểm số thay đổi
    public void UpdateSpeedByScore(int score)
    {
        // Kiểm tra điểm số và cập nhật tốc độ
        if (score >= 300 && currentLevel < 3)
        {
            currentSpeed = 10f;
            currentLevel = 3;
        }
        else if (score >= 200 && currentLevel < 2)
        {
            currentSpeed = 7f;
            currentLevel = 2;
        }
        else if (score >= 100 && currentLevel < 1)
        {
            currentSpeed = 5f;
            currentLevel = 1;
        }
    }
}
