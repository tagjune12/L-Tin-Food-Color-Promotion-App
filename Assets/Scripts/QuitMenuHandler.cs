using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenuHandler : MonoBehaviour, TouchableSpawnedObject
{
    public GameObject dialogUI;
    Camera deviceCamera;

    void Start()
    {
        deviceCamera = FindObjectOfType<Camera>();
    }

    public void DoTouchEvent()
    {
        if (dialogUI.activeSelf == false)
        {
            dialogUI.transform.position = deviceCamera.transform.forward * 2f;
            dialogUI.SetActive(true);
        }
    }
}
