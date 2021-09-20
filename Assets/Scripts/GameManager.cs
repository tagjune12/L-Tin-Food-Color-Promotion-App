using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public static bool fromPlaneDetectionToMain=false;
    void Awake()
    {
        Debug.Log("GameManager is awake!");
        gameManager = this;
    }

    public void offMenuObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void onMenuObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void LoadExpScene()
    {
       
        SceneManager.LoadScene("Plane Detection Scene");

    }

    public void LoadMainScene()
    {
        Debug.Log("Load Main Scene");
 
        SceneManager.LoadScene("Main");

    }
}
