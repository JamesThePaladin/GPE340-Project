using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Menus")]
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject optionsMenu;
    [Header("Player Data")]
    [SerializeField]
    private Image playerHealthBar;
    [SerializeField]
    private Text playerHealthText;
    [SerializeField]
    private Text playerAmmo;
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
        playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
        playerHealthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        playerAmmo = GameObject.FindGameObjectWithTag("PlayerAmmoDisplay").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterPlayerHealth(Pawn player) 
    {
        playerHealthBar.fillAmount = player.pawnHealth.GetHealth();
        playerHealthText.text = string.Format("Health: {0}%", Mathf.RoundToInt(player.pawnHealth.GetPercent() * 100f));
    }

    public void RegisterPlayerAmmo(Pawn player) 
    {
        if (player.weapon != null)
        {
            playerAmmo.text = string.Format("Ammo: {0}", player.weapon.currentAmmo.ToString() + "/" + player.weapon.maxAmmo.ToString());
        }
        else 
        {

        }
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void LoadNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
