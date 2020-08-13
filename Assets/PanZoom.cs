using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    float defaultZoomAmount;
    float currentZoomAmount;
    Camera cam;
    public Camera boundaryCamera;
    Vector2 screenBounds;
    private float viewWidth;
    private float viewHeight;
    Vector3 currentView;

    private void Start()
    {
        cam = Camera.main;
        defaultZoomAmount = cam.orthographicSize;
        screenBounds = boundaryCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, boundaryCamera.transform.position.z));

        currentView = cam.ScreenToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        viewWidth = currentView.x;
        viewHeight = currentView.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;

            //Vector3 viewPos = transform.position;
            //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + viewWidth, screenBounds.x - viewWidth);
            //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + viewHeight, screenBounds.y - viewHeight);
            //transform.position = viewPos;
        }
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
