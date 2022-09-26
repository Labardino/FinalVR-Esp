using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public Canvas mainCanvas, endGameCanvas;
    public TextMeshProUGUI pointText, canvasTitle;
    public static bool gameEnded;
    private void Awake()
    {
        if (instance != null && instance != this)
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
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        FindObjectOfType<AudioManager>().Play("lostMusic");
        canvasTitle.text = "You Lost";
        FinalStats();
    }

    public void FinalStats()
    {
        gameEnded = true;
        pointText.text = "Points: " + Pointsystem.totalPoints.ToString("F3");
        endGameCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    public void PlayerWin()
    {
        FindObjectOfType<AudioManager>().Play("winMusic");
        canvasTitle.text = "You Win";
        FinalStats();
    }
}
