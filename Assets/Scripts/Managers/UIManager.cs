using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private Canvas mainMenu;
    [SerializeField]
    private Canvas pauseMenu;
    [SerializeField]
    private Canvas optionsMenu;
    [Header("Player Data")]
    [SerializeField]
    private Image playerHealthBar;
    [SerializeField]
    private Text playerHealthText;
    //[Header("Enemy Data")]

    // Start is called before the first frame update
    void Start()
    {
        playerHealthBar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
        playerHealthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterPlayer(Pawn player) 
    {
        playerHealthBar.fillAmount = player.pawnHealth.GetHealth();
        playerHealthText.text = string.Format("Health: {0}%", Mathf.RoundToInt(player.pawnHealth.GetPercent() * 100f));
    }
}
