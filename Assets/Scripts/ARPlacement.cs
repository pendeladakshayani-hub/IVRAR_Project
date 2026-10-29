using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject solarSystemRoot;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(
            touch.position,
            hits,
            TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            solarSystemRoot.transform.position = hitPose.position;
            solarSystemRoot.transform.rotation = Quaternion.identity;

            solarSystemRoot.transform.localScale =
                Vector3.one * 0.03f;

            solarSystemRoot.SetActive(true);
        }
    }
}