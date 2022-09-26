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

    public void CustomDebug(string tex)
    {
        texto.text = tex;
    }
}
