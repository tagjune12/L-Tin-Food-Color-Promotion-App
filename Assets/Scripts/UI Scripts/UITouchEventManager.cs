using UnityEngine;

public class UITouchEventManager : MonoBehaviour
{
    Camera deviceCamera;
    RaycastHit[] hits;
    private GameObject hitObject;

    private void Start()
    {
        deviceCamera = GameObject.FindObjectOfType<Camera>();
    }
    
    private void Update()
    {
        // 터치를 했는지 체크
        if (Input.GetMouseButtonDown(0))
        {   // 스마트폰 화면에 터치가 입력된 좌표에서부터 Ray가 발사되도록 함 
            Ray ray = deviceCamera.ScreenPointToRay(Input.mousePosition);
            // ray의 길이는 무한으로 설정하여 ray가 통과하는 모든 오브젝트들의 정보를 얻는다.
            hits = Physics.RaycastAll(ray, Mathf.Infinity);

            for (int i = 0; i < hits.Length; i++)
            {   // ray가 통과한 콜라이더 오브젝트를 얻는다
                hitObject = hits[i].collider.gameObject;
                // ray와 충돌한 오브젝트의 레이어가 5번(즉 UI)이고 tag가 VRUIButton인경우 
                if (hitObject.layer == 5 && hitObject.CompareTag("VRUIButton"))
                {   // 해당 오브젝트의 OnClick메서드를 실행한다.
                    hitObject.GetComponent<ARUIComponent>().OnClick();
                }
            }
        }

    }
}
