using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    #region Singleton

    public static AudioClipManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public List<AudioClip> CD1_clips;
    public List<AudioClip> CD2_clips;

    // Update is called once per frame
    void Update()
    {

    }
}
