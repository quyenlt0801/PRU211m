using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoresManage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoresText;
    public float score;
    public static float scoresCount;

    // Start is called before the first frame update
    void Start()
    {
        scoresCount = score;
        scoresText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Players") != null)
        {
            scoresCount += 5 * Time.deltaTime;
            scoresText.text = "Scores : " +((int)scoresCount).ToString();
        }
        else
        {
            scoresText.text = "Scores : " + 0;
        }

        // Gọi hàm UpdateSpeedByScore để cập nhật tốc độ trong script YourScript

        if (scoresCount >= 100)
        {
            // moveLtoR.UpdateSpeedByScore(scoresCount);

        }
    }
}
