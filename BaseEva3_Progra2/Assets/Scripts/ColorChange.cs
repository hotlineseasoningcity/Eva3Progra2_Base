using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorChange : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private float time = 0f; 

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        time += Time.deltaTime;

        Color color = Color.HSVToRGB(time % 1, 1, 1);
        txt.color = color;
    }
}
