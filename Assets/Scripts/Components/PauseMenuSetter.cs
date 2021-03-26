using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.SetPauseMenu(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
