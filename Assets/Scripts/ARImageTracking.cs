using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARImageTracking : MonoBehaviour
{
    public GameObject solarSystemRoot;

    private ARTrackedImageManager trackedImageManager;

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage image in eventArgs.added)
        {
            ShowSolarSystem(image);
        }

        foreach (ARTrackedImage image in eventArgs.updated)
        {
            ShowSolarSystem(image);
        }
    }

    void ShowSolarSystem(ARTrackedImage image)
    {
        if (image.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
        {
            solarSystemRoot.SetActive(true);

            solarSystemRoot.transform.position = image.transform.position;
            solarSystemRoot.transform.rotation = image.transform.rotation;
        }
    }
}