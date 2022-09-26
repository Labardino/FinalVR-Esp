using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime;
    float startingTime = 60.0f;
    public TextMeshProUGUI texti;
    public bool gameEnded;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        texti = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        texti.text = "Time: " + currentTime.ToString("F0");
        if(currentTime <= 0.0f && !gameEnded)
        {
            GameManager.instance.PlayerWin();
            gameEnded = true;
        }
    }
}
