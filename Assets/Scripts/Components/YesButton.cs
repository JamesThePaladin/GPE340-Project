using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesButton : MonoBehaviour
{
    public void OnClick() 
    {
        UIManager.instance.PlayAgain();
    }
}
