using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudioCanvas : MonoBehaviour
{
    #region Singleton

    public static ToggleAudioCanvas instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject audioPlayerCanvas;

    private void Start()
    {
        audioPlayerCanvas.SetActive(false);
    }

    public void ToggleAudioPlayerCanvas()
    {
        audioPlayerCanvas.SetActive(!audioPlayerCanvas.activeSelf);
    }
}
