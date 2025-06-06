using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private AudioSource TrampAudio;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        TrampAudio = gameObject.GetComponent<AudioSource>();
        if (other.gameObject.tag == "Player")
        {
            TrampAudio.Play();
        }
    }
}
