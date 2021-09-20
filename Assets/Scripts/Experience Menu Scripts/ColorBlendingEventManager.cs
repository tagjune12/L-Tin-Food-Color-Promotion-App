using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlendingEventManager : MonoBehaviour
{
    private GameObject colorPortion;
    private GameObject foodObject;
    Color targetColor;
    private Camera deviceCamera;
    GameObject blendedFood;
    public GameObject pot;

    private void Start()
    {
        // 카메라 오브젝트 찾음
        deviceCamera = FindObjectOfType<Camera>();
    }

    // 지정된 음식오브젝트의 색을바꾸고 색이 변경된 새 음식오브젝트를 활성화
    void Blend()
    {
        Debug.Log("섞는중");
        
        // Vector3 targetPos = foodObject.transform.position + Vector3.one * 0.1f;
        // 음식오브젝트의 위치와 회전값을 얻어
        blendedFood=Instantiate(foodObject, foodObject.transform.position, foodObject.transform.rotation);
        blendedFood.GetComponent<Renderer>().material.color = targetColor;
        blendedFood.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {


        Debug.Log("충돌함");
        // 트리거에 감지된 오브젝트가 색소일 경우 colorPortion변수에 해당 오브젝트를 할당한다
        // 그리고 충돌한 오브젝트의 이름에 따라서 targetColor변수에 색상을 할당하여 변경할 색상을 지정한다.
        if (other.gameObject.tag == "Color")
        {
            Debug.Log("색소");
            colorPortion = other.gameObject;

            switch (colorPortion.name)
            {
                case "Red":
                    targetColor = Color.red + new Color(0,0,0,125);
                    break;
                case "Blue":
                    targetColor = Color.blue + new Color(0, 0, 0,170); 
                    break;
                case "Purple":
                    targetColor = new Color(173, 0, 255,180);
                    break;
                case "Yellow":
                    targetColor = new Color(255,253,0,255) + new Color(0, 0, 125,-80); // 255 253 0 255
                    break;
            }
        }
        // 트리거에 감지된 오브젝트가 음식일 경우 foodObject변수에 해당 오브젝트를 할당
        if (other.gameObject.tag == "Food")
        {
            Debug.Log("음식");
            foodObject = other.gameObject;
        }
        // colorPortion변수에는 색소오브젝트, 그리고 foodObject변수에 음식 오브젝트가 할당이 되었을 경우
        // 카메라(사용자의 현재 위치)보다 조금 앞에 색소가 첨가되어 색상이 변경된 오브젝트를 생성하고
        // 사용된 오브젝트는 비활성화 시켜 사용자에게 안보이게 한다. 
        if(colorPortion!=null && foodObject != null)
        {
            Debug.Log("섞는다?");
            Blend();

            colorPortion.gameObject.transform.position = deviceCamera.transform.forward * -1f;
            colorPortion.gameObject.SetActive(false);
            colorPortion = null;

            foodObject.gameObject.transform.position = deviceCamera.transform.forward * -1f;
            foodObject.gameObject.SetActive(false);
            foodObject = null;

            pot.gameObject.transform.position = deviceCamera.transform.forward * -1f;
            pot.gameObject.SetActive(false);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    other.gameObject.transform.position = deviceCamera.transform.forward * -1f;
    //    other.gameObject.SetActive(false);
    //}
}
