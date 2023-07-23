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
        // Load the player's score from PlayerPrefs
        LoadPlayerData();

        scoresText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Players") != null)
        {
            scoresCount += 5 * Time.deltaTime;
            scoresText.text = "Scores : " + ((int)scoresCount).ToString();
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

    private void LoadPlayerData()
    {
        // Load player's score from PlayerPrefs
        scoresCount = PlayerPrefs.GetFloat("PlayerScore", 0f);
    }

    private void SavePlayerData()
    {
        // Save player's score to PlayerPrefs
        PlayerPrefs.SetFloat("PlayerScore", scoresCount);

        // Save PlayerPrefs data
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        // Save player's score when the game object is destroyed (e.g., when the scene changes)
        SavePlayerData();
    }
}
