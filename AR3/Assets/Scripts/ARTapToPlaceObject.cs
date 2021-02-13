using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
  public GameObject objectToPlace;
  public GameObject placementIndicator;
  // Data structure that discribes the position and rotation of the 3D point
  private Pose placementPose;
  private bool placementPoseIsValid = true;
  private ARRaycastManager raycastManager;
  
  // Start is called before the first frame update
  void Start()
  {
    //arOrigin = FindObjectOfType<ARSessionOrigin>();
    raycastManager = FindObjectOfType<ARRaycastManager>();
  }


  // Update is called once per frame
  void Update()
  {
    UpdatePlacemantPose();
    UpdatePlacemantIndicator();

    // If user finger is on the screen and touch is just began, we can place the object
    //if(placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //{
    //  PlaceObject();
      
    //}
  }

  public void PlaceObject()
  {
        if (placementPoseIsValid) Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
  }

  private void UpdatePlacemantIndicator()
  {
    if (placementPoseIsValid) // Show indicator
    {
      placementIndicator.SetActive(true);
      placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
    }
    else // Hide indicator
    {
      placementIndicator.SetActive(false); 
    }
  }

  private void UpdatePlacemantPose()
  {
//    var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
    var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
    var hits = new List<ARRaycastHit>();

    raycastManager.Raycast(screenCenter, hits, TrackableType.Planes); 

    placementPoseIsValid = hits.Count > 0;
    if (placementPoseIsValid)
    {
      placementPose = hits[0].pose;
      var cameraForward = Camera.main.transform.forward;
      var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
      placementPose.rotation = Quaternion.LookRotation(cameraBearing);
    }
  }
}
