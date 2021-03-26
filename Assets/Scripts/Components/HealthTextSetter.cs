using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.SetHealthTextDisplay(GetComponent<Text>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
