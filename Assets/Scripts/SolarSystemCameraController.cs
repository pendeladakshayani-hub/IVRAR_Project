using UnityEngine;

public class SolarSystemCameraController : MonoBehaviour
{
    public Transform target;

    public float rotationSpeed = 5f;
    public float zoomSpeed = 5f;

    public float minDistance = 15f;
    public float maxDistance = 60f;

    public float focusDistance = 8f;
    public float smoothRotation = 8f;
    public float smoothZoom = 8f;

    private float distance;
    private float targetDistance;

    private float yaw;
    private float pitch;

    private float lastTouchDistance;

    void Start()
    {
        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.position);
            targetDistance = distance;

            Vector3 angles = transform.eulerAngles;
            yaw = angles.y;
            pitch = angles.x;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        // Mouse drag to rotate
        if (Input.GetMouseButton(0))
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;

            pitch = Mathf.Clamp(pitch, 10f, 80f);
        }

        // Mouse wheel to zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            targetDistance -= scroll * zoomSpeed;
            targetDistance = Mathf.Clamp(
                targetDistance,
                minDistance,
                maxDistance
            );
        }

        // Touch pinch to zoom
if (Input.touchCount == 2)
{
    Touch touch0 = Input.GetTouch(0);
    Touch touch1 = Input.GetTouch(1);

    float currentTouchDistance =
        Vector2.Distance(touch0.position, touch1.position);

    if (touch0.phase == TouchPhase.Began ||
        touch1.phase == TouchPhase.Began)
    {
        lastTouchDistance = currentTouchDistance;
    }
    else
    {
        float difference = currentTouchDistance - lastTouchDistance;

        targetDistance -= difference * 0.01f;

        targetDistance = Mathf.Clamp(
            targetDistance,
            minDistance,
            maxDistance
        );

        lastTouchDistance = currentTouchDistance;
    }
}

// Touch swipe to rotate
if (Input.touchCount == 1)
{
    Touch touch = Input.GetTouch(0);

    if (touch.phase == TouchPhase.Moved)
    {
        Vector2 delta = touch.deltaPosition;

        yaw += delta.x * rotationSpeed * 0.01f;
        pitch -= delta.y * rotationSpeed * 0.01f;

        pitch = Mathf.Clamp(pitch, 10f, 80f);
    }
}

        // Smooth rotation
        Quaternion targetRotation =
            Quaternion.Euler(pitch, yaw, 0f);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            smoothRotation * Time.deltaTime
        );

        // Smooth zoom
        distance = Mathf.Lerp(
            distance,
            targetDistance,
            smoothZoom * Time.deltaTime
        );

        // Keep camera around selected planet
        transform.position =
            target.position -
            transform.forward * distance;
    }

    public void FocusOnPlanet(Transform newTarget)
    {
        target = newTarget;
        targetDistance = focusDistance;
    }
}