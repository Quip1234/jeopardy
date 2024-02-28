using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public void ResetAllButtons()
    {
        Highlighter[] buttons = FindObjectsOfType<Highlighter>();
        foreach (Highlighter button in buttons)
        {
            button.ResetButton();
        }
    }
  
  
        public void OnResetButtonClick()
        {
            Highlighter.ResetAllButtons();
        }
    
}