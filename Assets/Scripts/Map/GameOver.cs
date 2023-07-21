using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoresText;


    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Players") == null)
        {
            gameOverPanel.SetActive(true);

            scoresText.text = "Score: " + ((int)ScoresManage.scoresCount).ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoresManage.scoresCount = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
