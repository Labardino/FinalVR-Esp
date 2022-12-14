using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pointsystem : MonoBehaviour
{
    public static float totalPoints;
    public static bool changePoints;
    public TextMeshProUGUI pointText;
    // Start is called before the first frame update
    void Start()
    {
        totalPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(changePoints)
        {
            PointUpdateUI();
            changePoints = false;
        }
    }

    public void PointUpdateUI()
    {
        pointText.text = "Points: " + totalPoints.ToString("F3");
    }
}
