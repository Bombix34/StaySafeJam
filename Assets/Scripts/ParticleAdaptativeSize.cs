using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAdaptativeSize : MonoBehaviour
{
    private ParticleSystem particles;
    private float particleInitSize;
    private PlayerManager player;

    private void Start()
    {
        player = PlayerManager.Instance;
        particles = GetComponent<ParticleSystem>();
        particleInitSize = particles.startSize;
    }

    private void Update()
    {
        particles.startSize = player.GetAdaptedValue(particleInitSize);
    }
}
