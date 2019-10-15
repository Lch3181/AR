using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class PlayVideoOnPress : MonoBehaviour {

    [Header("Video Name (Ex: video.mp4)")]
    public string videoPath;

    [Header("Mobile/Handheld Video Parameters")]
    public FullScreenMovieControlMode MobileVideoControlMode = FullScreenMovieControlMode.Full;
    public FullScreenMovieScalingMode MobileVideoScalingMode = FullScreenMovieScalingMode.AspectFit;
    public Color MobileVideoBackgroundColor = Color.black;

    [Header("PC Video Parameters")]
    public bool usingPCVideoPlayer;
    public VideoPlayer PCVideoPlayer;

    bool UsingPC;

    // Use this for initialization
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
        {
            UsingPC = true;
        }
    }

    private void Update()
    {
        if (!usingPCVideoPlayer|| PCVideoPlayer.url == "")
            return;

        if(!PCVideoPlayer.isPlaying && PCVideoPlayer.time == 0)
        {
            VuforiaBehaviour.Instance.enabled = true;
            usingPCVideoPlayer = false;
        }
        else
        {
            //Pause/Play
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(PCVideoPlayer.isPlaying)
                {
                    PCVideoPlayer.Pause();
                }
                else
                {
                    PCVideoPlayer.Play();
                }
            }

            //Move Backward
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                PCVideoPlayer.time -= 1f;
            }

            //Move Forward
            if (Input.GetKey(KeyCode.RightArrow))
            {
                PCVideoPlayer.time += 1f;
            }

            //Move Forward
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PCVideoPlayer.Stop();
            }
        }
    }

    private void OnMouseDown()
    {
        if (!UsingPC)
        {
            Handheld.PlayFullScreenMovie(videoPath, MobileVideoBackgroundColor, MobileVideoControlMode, MobileVideoScalingMode);
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
        else
        {
            VuforiaBehaviour.Instance.enabled = false;
            PCVideoPlayer.url = Application.streamingAssetsPath+"/" + videoPath;
            PCVideoPlayer.Play();
            usingPCVideoPlayer = true;
        }
    }
}
