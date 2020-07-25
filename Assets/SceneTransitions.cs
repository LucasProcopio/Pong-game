﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitions : MonoBehaviour
{
  public void LoadScene(string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
  public void QuitGame()
  {
    Application.Quit();
    Debug.Log("QUIT GAME");
  }
}
