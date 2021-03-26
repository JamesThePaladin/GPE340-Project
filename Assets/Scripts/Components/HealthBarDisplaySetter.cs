using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplaySetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.SetHealthBarDisplay(GetComponent<Image>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
