using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FromPlaneDetectionToMain : MonoBehaviour
{
    ARTrackedImageManager trackedImgManager;

    public GameObject mainMenu;
    public GameObject mainUI;
    public GameObject aimImage;

    void Awake()
    {
        // 이미지가 감지되었을경우 trackedImgManager를 비활성화하여 이미지 인식을 비활성화하고
        // 메인메뉴와 메인UI를 띄운다.
        trackedImgManager = FindObjectOfType<ARTrackedImageManager>();
        if (GameManager.fromPlaneDetectionToMain==true)
        {
            trackedImgManager.enabled = false;
            mainMenu.SetActive(true);
            mainUI.SetActive(true);
            aimImage.SetActive(false);
            GameManager.fromPlaneDetectionToMain = false;
        }        
    }

}
