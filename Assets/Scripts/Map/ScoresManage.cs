using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresManage : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoresText;
    public static int scoresCount;
    // Start is called before the first frame update
    void Start()
    {
        scoresText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        scoresText.text = "Scores : " + scoresCount.ToString();
    }
}
