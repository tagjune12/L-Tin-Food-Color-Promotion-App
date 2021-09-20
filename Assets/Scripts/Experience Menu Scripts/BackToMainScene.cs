using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainScene : MonoBehaviour, ARUIComponent
{

    public void OnClick()
    {
        GameManager.fromPlaneDetectionToMain = true;
        GameManager.gameManager.LoadMainScene();
    }
}
