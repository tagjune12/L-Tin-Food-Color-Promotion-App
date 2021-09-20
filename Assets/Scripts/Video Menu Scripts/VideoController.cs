using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour, ARUIComponent
{
    public VideoPlayer videoPlayer;

    // 제품 사용영상메뉴에서 버튼클릭시 발생하는 이벤트 함수
    public void OnClick()
    {   // 비디오가 플레이중일때 일시정지
        if (videoPlayer.isPlaying==true)
        {
            videoPlayer.Pause();
            Debug.Log("Pause Video");
        }
        // 비디오가 일시정지상태일때 플레이
        else
        {
            videoPlayer.Play();
            Debug.Log("Play Video");
        }
    }
}
