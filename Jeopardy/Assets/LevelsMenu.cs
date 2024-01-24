using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
  public void OpenLevel(int levelId)
    {
        string levelName = "C1-" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
