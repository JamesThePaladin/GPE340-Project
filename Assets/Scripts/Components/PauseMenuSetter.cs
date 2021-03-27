/*This script was originally designed just to set the pauseMenu variable in the UI Manager
 But I've since found a need to include methods to access UIManager functions when it does not originate from the pause menu's scene.
 So button events are now included on here too
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //set yourself as the Pause Menu in the UIManager
        UIManager.instance.SetPauseMenu(this.gameObject);
        //Deactivate yourself so the game doesn't start with you up
        this.gameObject.SetActive(false);
    }

    //These are the functions mentioned in the header comment
    public void ResumeGame() 
    {
        UIManager.instance.Resume();
    }

    public void EnableOptions() 
    {
        UIManager.instance.OpenOptionsMenu();
    }

    public void QuitGameRunTime() 
    {
        UIManager.instance.QuitGame();
    }
}
