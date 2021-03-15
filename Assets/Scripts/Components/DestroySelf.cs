using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField, Range(0,5), Tooltip("The time the object exists within the scene before destroying itself.")]
    private float lifeSpan;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
}
