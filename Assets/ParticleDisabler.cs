using UnityEngine;
using System.Collections.Generic;

public class ParticleDisabler : MonoBehaviour
{
    #region Singleton

    public static ParticleDisabler instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ParticleDisabler found!");
            return;
        }
        instance = this;
    }

    #endregion

    public List<GameObject> particles;
    bool status;

    public void ToggleParticles(bool onOff)
    {
        Debug.Log("toggled particles");

        foreach(GameObject part in particles)
        {
            part.SetActive(onOff);
        }
    }
}
