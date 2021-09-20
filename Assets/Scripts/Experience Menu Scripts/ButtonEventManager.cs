using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventManager : MonoBehaviour
{
    public Camera deviceCamera;
    public GameObject otherDialog;

    public void SpawnDialog(GameObject dialog)
    {
        dialog.SetActive(true);
        dialog.transform.position = deviceCamera.transform.forward * 2f;
        dialog.transform.rotation = Quaternion.LookRotation(deviceCamera.transform.forward);

        otherDialog.SetActive(false);
    }
}
