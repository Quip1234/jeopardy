using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Color wantedColor;
    public Button button;
    public void ChangeButtonColor()
     {
        ColorBlock cb = button.colors;
        cb.normalColor = wantedColor;
        cb.highlightedColor = wantedColor;  
        cb.pressedColor = wantedColor;
        button.colors = cb;
     }
    
}
