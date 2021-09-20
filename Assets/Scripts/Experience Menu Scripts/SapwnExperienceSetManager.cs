using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SapwnExperienceSetManager : MonoBehaviour
{
    public GameObject experienceSet;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private ARAnchorManager anchorManager;
    
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        anchorManager = FindObjectOfType<ARAnchorManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {   // 스크린 터치가 여러개 감지 되었을경우
            if (Input.touchCount > 0)
            {
                // 가장 첫번째로 입력된 터치를 입력값으로 사용한다.
                Touch touch = Input.GetTouch(0);
                // 터치가 시작되었을경우(화면에 손가락이 닿는 순간)
                if (touch.phase == TouchPhase.Began)
                {   // UI를 터치한게 아닌경우만 실행
                    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {   // Ray를 발사하고 AR Foundation에서 감지하여 만들어낸 평면과 부딫혔는지 체크한다.
                        if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                        {   // 부딫힌 평면에 Ray가 닿은 좌표에 앵커를 추가하여 그 위치에 오브젝트를 생성하고 고정시킬 수 있도록 한다. 
                            var anchor = anchorManager.AddAnchor(hits[0].pose);
                            experienceSet.SetActive(true);
                            experienceSet.transform.position = anchor.transform.position;
                            experienceSet.transform.localScale = Vector3.one * 0.3f;
                        }
                    }
                }
                // 이미 소환된 오브젝트(색소, 그릇, 음식)이 존재하고 스마트폰 스크린에 터치한 상태로 손가락을 움직이는 경우
                // 소환된 오브젝트가 손가락을 따라서 움직일 수 있도록 한다.
                if ((touch.phase==TouchPhase.Moved) && experienceSet != null)
                {
                    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        // Ray를 발사하고 AR Foundation에서 감지하여 만들어낸 평면과 부딫혔는지 체크한다.
                        if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                        {   // 부딫힌 평면에 Ray가 닿은 좌표에 앵커를 추가하여 생성된 오브젝트가 그 위치에 고정될 수 있도록 한다.
                            var anchor = anchorManager.AddAnchor(hits[0].pose);

                            experienceSet.transform.position = anchor.transform.position;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        
    }
}
