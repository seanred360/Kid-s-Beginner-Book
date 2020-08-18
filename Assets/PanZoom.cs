
using UnityEngine;
using DG.Tweening;

public class PanZoom : MonoBehaviour
{

    #region Singleton

    public static PanZoom instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PanZoom found!");
            return;
        }
        instance = this;
    }

    #endregion

    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    float currentZoomAmount;
    Camera cam;
    public Camera boundaryCamera;
    Vector2 screenBounds;
    private float viewWidth;
    private float viewHeight;
    Vector3 currentView;
    Vector3 originalPos;
    float originalOrthographicSize;

    private void Start()
    {
        cam = Camera.main;
        screenBounds = boundaryCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, boundaryCamera.transform.position.z));

        viewHeight = cam.orthographicSize /2;
        viewWidth = viewHeight / Screen.height * Screen.width;

        originalPos = cam.transform.position;
        originalOrthographicSize = cam.orthographicSize;
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

            Vector3 viewPos = cam.transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + viewWidth, screenBounds.x - viewWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + viewHeight, screenBounds.y - viewHeight);

            transform.position = viewPos;
        }
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    public void ResetView()
    {
        cam.transform.DOMove(originalPos, .5f, false);
        cam.DOOrthoSize(originalOrthographicSize, .5f);
        //cam.transform.position = originalPos;
        //cam.orthographicSize = originalOrthographicSize;
    }
}
