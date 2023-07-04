using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresManage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoresText;
    public static int scoresCount;

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
        scoresText.text = "Scores : " + scoresCount.ToString();

        // Gọi hàm UpdateSpeedByScore để cập nhật tốc độ trong script YourScript

        if (scoresCount >= 100)
        {
            // moveLtoR.UpdateSpeedByScore(scoresCount);

        }
    }
}
