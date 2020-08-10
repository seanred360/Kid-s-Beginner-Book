using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager_KBASB : MonoBehaviour
{
    #region Singleton

    public static AudioClipManager_KBASB instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public List<AudioClip> KBA_CD1_clips;
    public List<AudioClip> KBA_CD2_clips;

    private void Start()
    {
        
    }
}
