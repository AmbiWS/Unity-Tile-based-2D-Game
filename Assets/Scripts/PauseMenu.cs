using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    private bool paused = false;
   

    private void Start()
    {
        PauseUI = GameObject.FindGameObjectWithTag("PauseUI");
        PauseUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }


    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        EnemyAI_Rogue.roguesCount = 0;
        SceneManager.LoadScene("FirstChapterLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
