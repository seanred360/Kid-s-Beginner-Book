using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager_KBBSB : MonoBehaviour
{
    #region Singleton

    public static AudioClipManager_KBBSB instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public List<AudioClip> KBB_CD1_clips;
    public List<AudioClip> KBB_CD2_clips;

    // Update is called once per frame
    void Update()
    {
        
    }
}
