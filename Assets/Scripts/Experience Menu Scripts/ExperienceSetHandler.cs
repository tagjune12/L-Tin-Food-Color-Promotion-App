using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSetHandler : MonoBehaviour,TouchableSpawnedObject
{
    public void DoTouchEvent()
    {
        GameManager.gameManager.LoadExpScene();
    }
}
