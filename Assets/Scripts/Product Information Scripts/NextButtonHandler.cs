using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonHandler : MonoBehaviour, TouchableSpawnedObject
{
    // 상품정보를 보여주는 오브젝트
    public GameObject InfoView;
    // 보여줄 상품정보들을 담고있는 텍스쳐 배열
    public Texture[] productImage;
    // 상품정보 인덱스
    static int infoIndex;

    void Start()
    {
        infoIndex = 0;
    }
    // 터치시 다음 상품정보를 보여준다.
    public void DoTouchEvent()
    { 
        Debug.Log("Touch Event is work");

        if (infoIndex == productImage.Length-1) 
        {
            infoIndex = 0; 

        }
        else
        {
            infoIndex++;

        }
        Debug.Log("Index: " + infoIndex);
        // InfoView의 메시를 다른 텍스쳐로 바꾼다.
        InfoView.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", productImage[infoIndex]);



    }

}
