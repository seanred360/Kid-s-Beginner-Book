using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    GameObject audioPlayerCanvas;

    private void Start()
    {
        audioPlayerCanvas = AudioPlayerManager.instance.audioPlayerCanvas;
        audioPlayerCanvas.SetActive(false);
    }

    public void ToggleAudioPlayerCanvas()
    {
        audioPlayerCanvas.SetActive(!audioPlayerCanvas.activeSelf);
    }
}
