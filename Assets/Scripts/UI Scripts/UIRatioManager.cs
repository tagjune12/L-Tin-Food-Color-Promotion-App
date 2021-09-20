using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRatioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);//  16:9비율로 UI해상도 고정
    }

    
}
