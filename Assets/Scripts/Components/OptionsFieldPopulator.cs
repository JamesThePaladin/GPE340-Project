/*
    This script populates the drop downs in the option menu and sets the variable optionsMenu in UI Manager to the object this is attached to.
 */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsFieldPopulator : MonoBehaviour
{
    [SerializeField]
    private Dropdown resolutionDropDown;
    [SerializeField]
    private Dropdown qualityDropDown;
    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private Slider soudnSlider;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Toggle fullScreenToggle;
    [SerializeField]
    private Button applyButton;

    private void Awake()
    {
        resolutionDropDown.ClearOptions();
        List<string> resolutions = new List<string>();
        for (int i = 0; i < Screen.resolutions.Length; i++) 
        {
            resolutions.Add(string.Format("{0} x {1}", Screen.resolutions[i].width, Screen.resolutions[i].height));
        }
        resolutionDropDown.AddOptions(resolutions);
        qualityDropDown.ClearOptions();
        qualityDropDown.AddOptions(QualitySettings.names.ToList());
    }
    private void Start()
    {
        UIManager.instance.SetOptionsMenu(this.gameObject);
        this.gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master Volume", masterSlider.maxValue);
        fullScreenToggle.isOn = Screen.fullScreen;
        qualityDropDown.value = QualitySettings.GetQualityLevel();
        applyButton.interactable = false;
    }

    public void DisableOptions() 
    {
        UIManager.instance.CloseOptionsMenu();
    }
}
