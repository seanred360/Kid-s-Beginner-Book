using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    #region Singleton

    public static AudioPlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public List<AudioClip> KBA_CD1_clips;
    public List<AudioClip> KBA_CD2_clips;
    public List<AudioClip> KBA_CDWB_clips;
    public List<AudioClip> KBB_CD1_clips;
    public List<AudioClip> KBB_CD2_clips;
    public List<AudioClip> KBB_CDWB_clips;

    public GameObject audioPlayerCanvas;

    public enum bookName
    {
        KBA,KBB
    }

    public enum CDNumber
    {
        CD1,CD2,CDWB
    }

    private void Start()
    {
        //LoadAudioClips(KBA_CD1_clips, bookName.KBA, CDNumber.CD1);
        //LoadAudioClips(KBA_CD2_clips, bookName.KBA, CDNumber.CD2);
        //LoadAudioClips(KBA_CDWB_clips, bookName.KBA, CDNumber.CDWB);

        //LoadAudioClips(KBB_CD1_clips, bookName.KBB, CDNumber.CD1);
        //LoadAudioClips(KBB_CD2_clips, bookName.KBB, CDNumber.CD2);
        //LoadAudioClips(KBB_CDWB_clips, bookName.KBB, CDNumber.CDWB);
    }

    void LoadAudioClips(List<AudioClip> clipArray, bookName book, CDNumber cd)
    {
        Object[] clips = Resources.LoadAll(book.ToString() + "/" + cd.ToString(), typeof(AudioClip));
        for (int i = 0; i < clips.Length; i++)
        {
            clipArray.Add((AudioClip)clips[i]);
        }
    }
}
