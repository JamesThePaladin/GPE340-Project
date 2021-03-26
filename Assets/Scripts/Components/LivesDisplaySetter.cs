using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplaySetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.SetLivesDisplay(GetComponent<Text>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
