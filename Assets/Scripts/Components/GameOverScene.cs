using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public void LoadMainMenu() 
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ReloadLevel() 
    {
        SceneManager.LoadSceneAsync("Level 1");
    }
}
