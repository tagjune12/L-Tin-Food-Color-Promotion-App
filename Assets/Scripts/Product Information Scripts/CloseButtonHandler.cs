using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonHandler : MonoBehaviour, TouchableSpawnedObject
{
    public GameObject targetView;

    public void DoTouchEvent()
    {
        targetView.SetActive(false);
    }

    public void UpdateTransfrom(Transform transform)
    {
        // nothing
    }
}
