using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour
{
    public void OnClick() 
    {
        UIManager.instance.ReturnToMain();
    }
}
