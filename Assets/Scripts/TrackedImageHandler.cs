using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class TrackedImageHandler : MonoBehaviour
{
    public Camera arCamera;
    public ARTrackedImageManager trackedImageManager;
    public GameObject mainMenu;
    public GameObject mainUI;
    public Camera deviceCamera;
    public GameObject aimImage;

    // private ARPointCloudManager pointCloudManager;
    private ARPlaneManager planeManager;
   
    void Start()
    {   // 이미지 감지 및 인식을 위해 사용하는 TrackedImageManager
        trackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        // 평면감지를 위해 사용하는 PlaneManager
        planeManager = GetComponent<ARPlaneManager>();
        Debug.Log("Program is Start!");
    }


    private void OnEnable()
    {   // 스크립트 활성화시 trackedImagesChanged이벤트에 OnTrackedImagesChanged메서드를 등록하여
        // 매 프레임마다 이벤트 발생시 호출하도록 한다.
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;   
    }

    private void OnDisable()
    {
        // 스크립트 비활성화시 trackedImagesChanged이벤트에 등록된 OnTrackedImagesChanged메서드를 등록해제 한다.
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            // 이미지가 인식되었을경우 메인메뉴를 활성화하여 눈에 보일 수 있도록한다.
            Debug.Log("Image is Tracked!");
            mainMenu.SetActive(true);
            mainMenu.transform.position = deviceCamera.transform.forward * 10f;
            GameManager.gameManager.onMenuObject(mainUI);
            //pointCloudManager.enabled = true;
            planeManager.enabled = true;
            aimImage.SetActive(false);

        }
    }


    private void Update()
    {   // 스마트폰 소프트키중 뒤로가기 버튼을 누르면 앱 종료
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}
