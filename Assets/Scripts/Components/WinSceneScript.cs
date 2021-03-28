using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneScript : MonoBehaviour
{
    public void LoadMainMenu() 
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void RestartLevelOne() 
    {
        SceneManager.LoadSceneAsync("Level 1");
    }
}
