using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    private void Awake()
    {
        ParticleDisabler.instance.particles.Add(gameObject);
    }
}
