using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bgm2;
    public AudioClip start;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(start);
        audioSource.clip = bgm2;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
