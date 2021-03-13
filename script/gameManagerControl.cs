using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerControl : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()//按ESC結束程式
    {
        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
        scoreControler.score = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        scoreControler.score = 0;
    }

}
