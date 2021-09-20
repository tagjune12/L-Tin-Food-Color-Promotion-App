using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptButtonHandler : MonoBehaviour, ARUIComponent
{
    public void OnClick()
    {
        Application.Quit();
    }

}
