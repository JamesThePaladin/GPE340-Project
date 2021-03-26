using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.isGameStart = true;
        NotGameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NotGameStart() 
    {
        yield return new WaitForSeconds(3);
        GameManager.instance.isGameStart = false;
        Destroy(this);
    }
}
