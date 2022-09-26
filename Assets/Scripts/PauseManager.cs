using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance { get; private set; }
    public Canvas pauseCanvas, mainCanvas;
    public static bool gameIsPaused;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Start) && !GameManager.gameEnded)
        {
            if(gameIsPaused)
            {
                ResumePlay();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumePlay()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
    public void PauseGame()
    {
        pauseCanvas.enabled = true;
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
