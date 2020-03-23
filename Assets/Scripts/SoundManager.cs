using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public AudioSource[] audiosources;
    public PitchVolumeAudio deathSound;                  //0
    public PitchVolumeAudio spawnSound;                 //1
    public PitchVolumeAudio eatSound;                   //2
    public PitchVolumeAudio attractionCreate;            //3
    public PitchVolumeAudio attractionDestroy;           //4
    public PitchVolumeAudio birthPlanet;                //5
    public PitchVolumeAudio birthStar;                   //6
    public PitchVolumeAudio birthTrou;                  //7

    void Start()
    {
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].loop = false;
        }
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
            case 3:
                attractionCreate.Play(GetAudioSourceAvailable());
                break;
            case 4:
                attractionDestroy.Play(GetAudioSourceAvailable());
                break;
            case 5:
                birthPlanet.Play(GetAudioSourceAvailable());
                break;
            case 6:
                birthStar.Play(GetAudioSourceAvailable());
                break;
            case 7:
                birthTrou.Play(GetAudioSourceAvailable());
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