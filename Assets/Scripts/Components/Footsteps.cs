using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField, Tooltip("The audio source to play through")]
    private AudioSource audioSource;
    [SerializeField, Tooltip("The sound the footstep makes")]
    private AudioClip footstepClip;

    private void AnimationEventFootstep() 
    {
        audioSource.PlayOneShot(footstepClip);
    }
}
