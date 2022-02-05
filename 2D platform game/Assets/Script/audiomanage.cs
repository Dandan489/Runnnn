using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiomanage : MonoBehaviour
{
    public AudioSource audi;
    public AudioSource click;
    public float musicVolume = 0.25f;

    void Start()
    {
        audi.time = GameValue.music_time;
        Debug.Log(audi.time);
        audi.Play();
    }
    void Update()
    {
        audi.volume = musicVolume;
    }

    public void ChangeVolume(float vol)
    {
        musicVolume = vol;
    }

    public void ClickSound()
    {
        click.time = 0.99f;
        click.Play();
    }
}
