/*****************************************************************************
// File Name :         VideoPlayerTimeSender.cs
// Author :            Kyle Grenier
// Creation Date :     09/18/2021
//
// Brief Description : Saves the time of the VideoPlayer whenever the attached GameObject gets disabled.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerTimeSender : MonoBehaviour
{
    /// <summary>
    /// The VideoPlayer component.
    /// </summary>
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

#if UNITY_EDITOR
    /// <summary>
    /// Raise the event whenever the attached application quits.
    /// </summary>
    private void OnApplicationQuit()
    {
        print("Setting Pref to " + videoPlayer.time);
        PlayerPrefs.SetFloat("Time Elapsed", (float) videoPlayer.time);
    }
#endif
}
