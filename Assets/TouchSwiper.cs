using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public float percentThreshold = .2f;
    private int currentPage = 1;

    MobileBook book;

    // Start is called before the first frame update
    void Start()
    {
        book = GetComponent<MobileBook>();
    }
    public void OnDrag(PointerEventData data)
    {

    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            if (percentage > 0)
            {
                book.FlipPageRight();
            }
            else if (percentage < 0)
            {
                book.FlipPageLeft();
            }
        }
    }
}


