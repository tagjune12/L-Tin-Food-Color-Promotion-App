using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DropDownMenuEventManager : MonoBehaviour
{
    // 소환할 수 있는 오브젝트들이 담겨있는 GameObject 배열
    public GameObject[] placementObjects;
    public SapwnExperienceSetManager spawnExpSetManager;
    public Dropdown dropDown;


    public void ChangeTargetObject()
    {        
        int index = dropDown.value;
        // spawnExpSetManager의 experienceSet변수에 
        // Dropdown메뉴에서 선택한 오브젝트를 소환할 수 있도록 할당한다.
        spawnExpSetManager.experienceSet = placementObjects[index];
    }
}
