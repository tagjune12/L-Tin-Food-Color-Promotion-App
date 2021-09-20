using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ButtonHandler : MonoBehaviour
{
    public GameObject gameObject;



    public void OnClickUIOnOffButton(){

        if (!gameObject.activeSelf) // Turn On Main UI
        {
            GameManager.gameManager.onMenuObject(gameObject);

        }

        else // Turn off Main UI
        {
            GameManager.gameManager.offMenuObject(gameObject);

        }
    }
}
