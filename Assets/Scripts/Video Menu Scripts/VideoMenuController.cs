using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoMenuController : MonoBehaviour,ARUIComponent
{
    public GameObject targetView;
    public void OnClick()
    {
        targetView.SetActive(false);
    }
}
