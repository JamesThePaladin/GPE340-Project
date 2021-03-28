using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Menus")]
    //[SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private List<GameObject> menuPrefabs;
    public static bool isPaused = false;
    [Header("Player Data")]
    [SerializeField]
    private Image playerHealthBar;
    [SerializeField]
    private Text playerHealthText;
    [SerializeField]
    private Text playerAmmo;
    [SerializeField]
    private Text lives;
    //[Header("Enemy Data")]

    private void Awake()
    {
        // if instance is empty
        if (instance == null)
        {
            //store THIS instance of the class in the instance variable
            instance = this;
            //keep this instance of ui manager when loading new scenes
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //delete the new ui manager attempting to store itself, there can only be one.
            Destroy(this.gameObject);
            //display message in the console to inform of its demise
            Debug.Log("Warning: A second ui manager was detected and destrtoyed");
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player != null)
        {
            RegisterPlayerAmmo(GameManager.instance.playerPawn); 
        }
    }

    public void OpenOptionsMenu() 
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            UIManager.instance.mainMenu.SetActive(false);
            UIManager.instance.optionsMenu.SetActive(true);
        }
        else 
        {
            UIManager.instance.pauseMenu.SetActive(false);
            UIManager.instance.optionsMenu.SetActive(true);
        }
    }

    public void CloseOptionsMenu() 
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            UIManager.instance.optionsMenu.SetActive(false);
            UIManager.instance.mainMenu.SetActive(true);
        }
        else 
        {
            UIManager.instance.optionsMenu.SetActive(false);
            UIManager.instance.pauseMenu.SetActive(true);
        }
    }
    /// <summary>
    /// Pauses the game by setting the pause menu panel to active, the game time scale to 0. and isPaused boolean to true
    /// </summary>
    public void Pause()
    {
        //set the pause menu to active
        UIManager.instance.pauseMenu.SetActive(true);
        //set time scale to zero
        Time.timeScale = 0f;
        //set the pause bool to true
        isPaused = true;
    }

    /// <summary>
    /// Registers the player health and sets the healthbar fill image amount equal to the player's percentage of health
    /// </summary>
    /// <param name="player"></param>
    public void RegisterPlayerHealth(Pawn player) 
    {
        //set the fill amount
        playerHealthBar.fillAmount = player.pawnHealth.GetPercent();
        //set the text to display the percentage of the player's health
        playerHealthText.text = string.Format("Health: {0}%", Mathf.RoundToInt(player.pawnHealth.GetPercent() * 100f));
    }

    /// <summary>
    /// Registers the player's ammo to the display by setting the text using string.Format
    /// </summary>
    /// <param name="player"></param>
    public void RegisterPlayerAmmo(Pawn player) 
    {
        //if they have a weapon
        if (!player.weapon)
        {
            //dont do anything
            return;
        }
        //otherwise if they dont have a weapon
        else 
        {
            //set the text to display their current ammo / max ammo
            playerAmmo.text = string.Format("Ammo: {0}", player.weapon.currentAmmo.ToString() + "/" + player.weapon.maxAmmo.ToString());
        }
    }

    /// <summary>
    /// This function grabs the lives from GameManager and sets the lives display text to it
    /// </summary>
    public void RegisterPlayerLives() 
    {
        //format the lives from gamemanager into a string and set lives.text equal to it
        lives.text = string.Format("Lives: {0}", GameManager.instance.lives.ToString());
    }

    /// <summary>
    /// This function resumes the game after it has been paused
    /// </summary>
    public void Resume()
    {
        //set the pause menu's panel to inactive
        UIManager.instance.pauseMenu.SetActive(false);
        //set the time scale back to 1 so that time resumes normally
        Time.timeScale = 1f;
        //set the is paused bool to false
        isPaused = false;
    }

    /// <summary>
    /// This function just quits the game by calling Application.Qut
    /// </summary>
    public void QuitGame() 
    {
        Application.Quit();
    }

    /// <summary>
    /// This function returns to the main menu by loading it with its build index (0)
    /// </summary>
    public void ReturnToMain() 
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayAgain() 
    {
        SceneManager.LoadSceneAsync("Level 1");
    }
    /// <summary>
    /// This function loads the next scene and is called when starting the game
    /// </summary>
    public void LoadNextScene() 
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviousScene() 
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// This function is called at the beginning of the game or level to find all necessary objects
    /// </summary>
    private void FindGameStartObjects() 
    {
        playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
        playerHealthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        playerAmmo = GameObject.FindGameObjectWithTag("PlayerAmmoDisplay").GetComponent<Text>();
        lives = GameObject.FindGameObjectWithTag("LivesDisplay").GetComponent<Text>();
    }

    public void SetHealthBarDisplay(Image healthBar) 
    {
        playerHealthBar = healthBar;
    }

    public void SetHealthTextDisplay(Text healthText) 
    {
        playerHealthText = healthText;
    }

    public void SetAmmoDisplay(Text ammo) 
    {
        playerAmmo = ammo;
    }
    
    public void SetLivesDisplay(Text livesText) 
    {
        lives = livesText;
    }

    public void SetPauseMenu(GameObject menu) 
    {
        pauseMenu = menu;
    }

    public void SetOptionsMenu(GameObject menu) 
    {
        optionsMenu = menu;
    }
}
