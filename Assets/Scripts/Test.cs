using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    public TextMeshProUGUI texto;

    // Update is called once per frame
    void Update()
    {

    }

    public void CustomDebug()
    {
        texto.text = BowAnim.blendValue.ToString();
    }
}
