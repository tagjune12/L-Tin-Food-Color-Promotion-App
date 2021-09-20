using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSelectManager : MonoBehaviour, ARUIComponent
{
    // 영상을 보여주는 오브젝트(화면 역할)
    public GameObject targetVideoView;
    // 화면에 보여지는 영상
    public Texture videoTexture;
    // 동영상 재생기
    public VideoPlayer videoPlayer;
    // 재생할 동영상
    public VideoClip videoClip;



    void Start()
    {
        //youtubeplayer = GetComponent<YoutubePlayer>();
    }



    public void OnClick()
    {
        videoPlayer.Stop();
        // 비디오 플레이어에 의해 비춰질 텍스텨 할당
        videoPlayer.targetTexture = (RenderTexture)videoTexture;
        // 재생될 비디오 클립 설정
        videoPlayer.clip = videoClip;
        // 화면의 메시를 동영상으로 변경한다
        targetVideoView.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", videoTexture);
        // 동영상을 준비하고 재생한다.
        videoPlayer.Prepare();
        videoPlayer.Play();
    }

}
