using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MusicManager : Singleton<MusicManager>
{
    public AudioSource[] musicSource;
    public float musicVolume;
    public SoundManager Sound { get; set; }

    private int layerIndex = 0;

    private void Start()
    {
        Sound = GetComponent<SoundManager>();
        for(int i = 0; i < musicSource.Length; ++i)
        {
            musicSource[i].volume = 0f;
            musicSource[i].Play();
        }
    }

    public void LaunchMusic()
    {
        musicSource[0].DOFade(musicVolume,1f);
        musicSource[1].DOFade(musicVolume, 1f);
        layerIndex = 1;
    }

    public void AddLayer()
    {
        layerIndex++;
        if (layerIndex >= musicSource.Length)
            return;
        musicSource[layerIndex].DOFade(musicVolume, 1f);
    }
}
