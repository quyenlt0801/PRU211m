using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresManage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoresText;
    public static float scoresCount;

    [SerializeField]
    private MoveLtoR moveLtoR;
    // Start is called before the first frame update
    void Start()
    {
        scoresText = GetComponent<TextMeshProUGUI>();
        moveLtoR = GetComponent<MoveLtoR>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Players") != null)
        {
            scoresCount += 1 * Time.deltaTime;
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
