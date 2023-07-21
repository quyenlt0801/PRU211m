using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        ScoresManage.scoresCount = 0;
        SceneManager.LoadScene(1); 
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
