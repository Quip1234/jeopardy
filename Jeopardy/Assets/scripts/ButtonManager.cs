using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons;
    public int mainMenuSceneIndex = 0;

    private const string SELECTED_KEY_PREFIX = "ButtonSelected_";

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Initialize button states
        foreach (Button button in buttons)
        {
            string buttonKey = SELECTED_KEY_PREFIX + button.name;
            if (PlayerPrefs.GetInt(buttonKey, 0) == 1)
            {
                // Button was previously selected, darken it
                DarkenButton(button);
            }
        }
    }

    public void OnButtonClick(Button button)
    {
        string buttonKey = SELECTED_KEY_PREFIX + button.name;

        if (PlayerPrefs.GetInt(buttonKey, 0) == 0)
        {
            // Button was not previously selected, darken it
            DarkenButton(button);
            // Update PlayerPrefs to mark button as selected
            PlayerPrefs.SetInt(buttonKey, 1);
        }
        else
        {
            // Button was previously selected, revert its color
            LightenButton(button);
            // Update PlayerPrefs to mark button as not selected
            PlayerPrefs.SetInt(buttonKey, 0);
        }
    }

    void DarkenButton(Button button)
    {
        // Modify button color or transparency to make it darker
        ColorBlock colors = button.colors;
        colors.normalColor = Color.gray; // Darken color as desired
        button.colors = colors;
    }

    void LightenButton(Button button)
    {
        // Revert button color or transparency to its default state
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white; // Revert to default color
        button.colors = colors;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == mainMenuSceneIndex)
        {
            ResetButtonStates();
        }
    }

    void ResetButtonStates()
    {
        // Reset all button states to default and PlayerPrefs
        foreach (Button button in buttons)
        {
            string buttonKey = SELECTED_KEY_PREFIX + button.name;
            PlayerPrefs.DeleteKey(buttonKey); // Remove PlayerPrefs entry
            LightenButton(button); // Revert button appearance
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
