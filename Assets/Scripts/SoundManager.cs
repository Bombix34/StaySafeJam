using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public AudioSource[] audiosources;
    public PitchVolumeAudio deathSound;                  //0
    public PitchVolumeAudio spawnSound;                 //1
    public PitchVolumeAudio eatSound;                   //2

    void Start()
    {
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].loop = false;
        }
        StartCoroutine(StartSound());
    }

    private IEnumerator StartSound()
    {
        yield return new WaitForSeconds(0.9f);
        PlaySound(1);
    }

    public void PlaySound(int sound)
    {
        switch (sound)
        {
            case 0:
                deathSound.Play(GetAudioSourceAvailable());
                break;
            case 1:
                spawnSound.Play(GetAudioSourceAvailable());
                break;
            case 2:
                eatSound.Play(GetAudioSourceAvailable());
                break;
        }
    }

    public void GetAudioSourceAvailable(AudioClip clip)
    {
        for (int i = 0; i < audiosources.Length; i++)
        {
            if (!audiosources[i].isPlaying)
            {
                audiosources[i].loop = false;
                audiosources[i].clip = clip;
                audiosources[i].Play();
                return;
            }
        }
    }

    public AudioSource GetAudioSourceAvailable()
    {
        for (int i = 0; i < audiosources.Length; i++)
        {
            if (!audiosources[i].isPlaying)
            {
                return audiosources[i];
            }
        }
        return null;
    }
}