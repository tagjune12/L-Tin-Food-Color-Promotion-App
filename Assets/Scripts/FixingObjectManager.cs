using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FixingObjectManager : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private ARAnchorManager anchorManager;
    private List<ARRaycastHit> hits;
    private Camera deviceCamera;

    public GameObject existingObject;


    void Start()
    {
        anchorManager = FindObjectOfType<ARAnchorManager>();
        raycastManager = FindObjectOfType<ARRaycastManager>();
        deviceCamera = FindObjectOfType<Camera>();
        hits = new List<ARRaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {   //  터치가 여러개 감지되었을 경우
        if (Input.touchCount > 0)
        {
            // 가장먼저 인식된 터치만을 이용
            Touch touch = Input.GetTouch(0);
            // 터치가 인식된 순간
            if (touch.phase == TouchPhase.Began)
            {   // UI를 터치한게 아니라면
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    Debug.Log("Mouse is Clicked");
                    // ARRaycastManager가 존재할 경우
                    if (raycastManager != null)
                    {
                        try
                        {   //  터치한 좌표에서 Ray를 발사하여 인식된 평면과 충돌했을경우 충돌 정보를 얻어온다.
                            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                            {
                                Debug.Log("Add Anchor is Clear");
                                // 상품정보 메뉴가 카메라 바로 앞에 위치할 수 있도록 위치값을 지정하고
                                // 해당위치에 앵커를 추가하여 상품정보 메뉴가 해당 좌표에 고정될 수 있도록 한다.
                                Vector3 targetPosition = hits[0].pose.position + new Vector3(0, -hits[0].pose.position.y + deviceCamera.transform.position.y*0.6f, 0);

                                Pose targetPose = new Pose(targetPosition, hits[0].pose.rotation);
                                //var anchor = anchorManager.AddAnchor(hits[0].pose);
                                var anchor = anchorManager.AddAnchor(targetPose);

                                Debug.Log("anchor Clear");
                                existingObject.transform.position = anchor.transform.position;
                                // 생성된 상품정보 메뉴가 사용자에게 보일 수 있도록 회전값을 변경해준다.
                                existingObject.transform.LookAt(deviceCamera.transform);
                                existingObject.transform.localScale = Vector3.one * 0.1f;
                                Debug.Log("Transform Clear");
                                //Debug.Log("Distance: " + Vector3.Distance(targetPosition, deviceCamera.transform.position));
                            }
                            else
                            {
                                Debug.Log(raycastManager.Raycast(touch.position, hits, TrackableType.All));
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.LogWarning(ex);
                        }
                    }
                    else
                    {
                        Debug.Log("raycastManager is null");
                    }
                }
            }
            
        }
    }

}
