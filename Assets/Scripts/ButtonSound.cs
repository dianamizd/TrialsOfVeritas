using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSound;

    public void PlayButtonSound()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonSound);
    }
}
