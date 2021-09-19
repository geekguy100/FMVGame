/*****************************************************************************
// File Name :         MenuItems.cs
// Author :            Kyle Grenier
// Creation Date :     09/17/2021
//
// Brief Description : Script dedicated to creating custom editor buttons.
*****************************************************************************/
using UnityEngine;
using UnityEditor;
using UnityEngine.Video;

public class MenuItems : MonoBehaviour
{
    [MenuItem("Tools/FMV Maker/Create FMV Button")]
    private static void CreateFMVButton()
    {
        const string BTN_NAME = "FMVButton";
        GameObject buttonPrefab = Resources.Load<GameObject>(BTN_NAME);
        if (buttonPrefab == null)
        {
            Debug.LogWarning("[MenuItems]: Could not load FMV Button prefab. Check 'Resources' folder for GameObject named '" + BTN_NAME + "'.");
            return;
        }

        GameObject videoParent = GameObject.FindGameObjectWithTag("VideoParent");
        if (videoParent == null)
        {
            Debug.LogWarning("[MenuItems]: Could not find GameObject tagged 'VideoParent'. Aborting...");
            return;
        }

        VideoPlayer videoPlayer = videoParent.GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            Debug.LogWarning("[MenuItems]: GameObject tagged 'VideoParent' does not have the required VideoPlayer component. Aborting...");
            return;
        }

        FMVTimedObjectPopup popup = Instantiate(buttonPrefab, videoParent.transform).GetComponent<FMVTimedObjectPopup>();
        float popupTime;

        // If the game is currently running, we can get the current time
        // of the video player.
        if (Application.isPlaying)
        {
            print("[MenuItems]: Application is playing, so getting time from VideoPlayer...");
            popupTime = (float)videoPlayer.time;
        }
        // If the game is stopped, get the time elapsed from the PlayerPrefs.
        else
        {
            print("[MenuItems]: Application is stopped, so getting time from PlayerPrefs...");
            print("Time caught is " + PlayerPrefs.GetFloat("Time Elapsed"));
            popupTime = PlayerPrefs.GetFloat("Time Elapsed"); 
        }

        popup.PopupTime = popupTime;
    }
}