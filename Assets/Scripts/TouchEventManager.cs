using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TouchEventManager : MonoBehaviour
{
    Camera deviceCamera;
    // 터치 지속시간을 측정하기 위한 변수
    float timeLapse=0;

    private void Start()
    {
        deviceCamera = GameObject.FindObjectOfType<Camera>();
    }

    private void Update()
    {   // 짧게 터치했을경우
        if (Input.GetMouseButtonDown(0))
        {
            timeLapse = 0;
            // Spawned Object라는 태그를 가진 오브젝트를 찾는다
            DetectSpecificTagObject("Spawned Object");
        }
        // 길게 터치했을경우
        if (Input.GetMouseButton(0))
        {
            timeLapse += Time.deltaTime;
            if (timeLapse >= 0.3f) //0.3초 이상 눌렀을 경우
            {
                // Main Menu Item라는 태그를 가진 오브젝트를 찾는다.
                DetectSpecificTagObject("Main Menu Item");

            }
        }
    }
    // 터치시 특정 태그를 가진 오브젝트를 탐지하는 함수
    void DetectSpecificTagObject(String tag)
    {
        RaycastHit[] hits;
        // 스마트폰 화면에서 터치한 좌표에서부터 길이가 무한인 Ray를 발사합니다.
        Ray ray = deviceCamera.ScreenPointToRay(Input.mousePosition);
        // Ray에 맞은 모든 오브젝트의 정보를 얻어옵니다.
        hits = Physics.RaycastAll(ray, Mathf.Infinity);
        GameObject hitObject;
        try
        {
            for (int i = 0; i < hits.Length; i++)
            {
                hitObject = hits[i].collider.gameObject;
                // Ray에 맞은 오브젝트의 tag와 찾으려는 tag를 비교하여 일치할경우
                // 해당 오브젝트의 터치시 발생해야할 이벤트를 실행합니다.
                if (hitObject.CompareTag(tag))
                {
                    hitObject.GetComponent<TouchableSpawnedObject>().DoTouchEvent();
                    break;
                }
                else
                {
                    Debug.LogWarning("Failed: " + hits[i].collider.gameObject.name);
                    Debug.LogWarning("Failed: " + hits[i].collider.gameObject.tag);
                }
            }
        }
        catch(Exception ex)
        {
            Debug.LogError(ex);
        }
    }
}


