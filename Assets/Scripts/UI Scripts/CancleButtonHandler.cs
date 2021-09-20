using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CancleButtonHandler : MonoBehaviour,ARUIComponent
{
    public GameObject dialogUI;
    public void OnClick()
    {       
        dialogUI.SetActive(false);
    }
}
