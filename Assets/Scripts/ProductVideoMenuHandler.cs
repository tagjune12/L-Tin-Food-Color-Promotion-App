using System;
using UnityEngine;



public class ProductVideoMenuHandler : MonoBehaviour, TouchableSpawnedObject
{
    public GameObject productVideoView;
    public GameObject productInfoView;
    public Camera deviceCamera;
    public GameObject mainMenuObject;

    public void DoTouchEvent()
    {
        productInfoView.GetComponent<FixingObjectManager>().enabled = false;
        productVideoView.GetComponent<FixingObjectManager>().enabled = true;

        try
        {
            if (productVideoView.activeSelf == false) // 물품 비디오창이 없는 경우 소환
            {
                productVideoView.SetActive(true);
                productVideoView.transform.position = deviceCamera.transform.position + deviceCamera.transform.forward * 5f; // 카메라 보다 앞에 생성


                Vector3 videoViewScale = productVideoView.transform.localScale;
                productVideoView.transform.localScale = new Vector3(videoViewScale.x / 2, videoViewScale.y / 2, videoViewScale.z / 2);
                productVideoView.transform.LookAt(deviceCamera.transform);
                Debug.Log("Camera Position: " + deviceCamera.transform.position);
                Debug.Log("Local Position: " + productVideoView.transform.localPosition);
                Debug.Log("Global Position: " + productVideoView.transform.localPosition);
                GameManager.gameManager.offMenuObject(mainMenuObject);



            }

        }
        catch(Exception ex)
        {
            Debug.LogError(ex);
        }
        

    }

}
