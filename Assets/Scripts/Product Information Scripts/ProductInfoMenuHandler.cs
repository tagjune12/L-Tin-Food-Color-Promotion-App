using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ProductInfoMenuHandler : MonoBehaviour, TouchableSpawnedObject
{
    public GameObject productInfoView;
    public GameObject productVideoView;
    public Camera deviceCamera;
    public GameObject mainMenuObject;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();




    public void DoTouchEvent() {
        productInfoView.GetComponent<FixingObjectManager>().enabled = true;
        productVideoView.GetComponent<FixingObjectManager>().enabled = false;
        try
        {
            if (productInfoView.activeSelf == false) // 물품 정보창이 없는 경우 소환
            {

                productInfoView.SetActive(true);
                productInfoView.transform.position = deviceCamera.transform.position + deviceCamera.transform.forward * 10f; // 카메라 보다 앞에 생성
                Vector3 relativePos = deviceCamera.transform.position - productInfoView.transform.position;

                productInfoView.transform.LookAt(relativePos);


                Debug.Log("Camera Position: " + deviceCamera.transform.position);
                Debug.Log("Local Position: " + productInfoView.transform.localPosition);
                Debug.Log("Global Position: " + productInfoView.transform.localPosition);



                GameManager.gameManager.offMenuObject(mainMenuObject);

            }

        }
        catch(Exception ex)
        {
            Debug.LogError(ex);
        }
    }

}


