using UnityEngine;

public class DisablePanZoom : MonoBehaviour
{
    public void TogglePanZoom(bool state)
    {
        PanZoom.instance.canPan = state;
    }
}
