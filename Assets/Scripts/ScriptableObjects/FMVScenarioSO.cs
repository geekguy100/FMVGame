/*****************************************************************************
// File Name :         FMVScenarioSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/16/2021
//
// Brief Description : A SO that represents a "scenario" in the FMV movie.
                       I'm defining a scenario as a scene in the movie / a point in the game 
                       that the player has to make choices get to.

                       A scenario may have options the player has to make: do they choose path A or path B?
                       That choice will lead to yet another scenario. This means that scenarios are connected in a sort of
                       tree structure.
*****************************************************************************/
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "FMV Maker/Scenario", fileName = "New Scenario")]
public class FMVScenarioSO : SerializedScriptableObject
{
    [Tooltip("The video clip to play during this scenario.")]
    [SerializeField] private VideoClip videoClip;
    /// <summary>
    /// The VideoClip to play during this scenario.
    /// </summary>
    public VideoClip VideoClip
    {
        get
        {
            return videoClip;
        }
    }

    [Tooltip("The channel to receive video time elapsed calls from.")]
    [SerializeField] private DoubleChannelSO timeElapsedChannel;

    [Tooltip("True if the player will be required to make a choice.\n" +
             "False if scenario will automatically play into the next.")]
    [SerializeField] private bool choicesToBeMade;
    /// <summary>
    /// True if the player will be required to make a choice.
    /// False if scenario will automatically play into the next
    /// </summary>
    public bool ChoicesToBeMade
    {
        get
        {
            return choicesToBeMade;
        }
    }

    // Choices to be made
    [Tooltip("An array of popups that are instantiated in the scenario.")]
    [ShowIf("choicesToBeMade")]
    [AssetsOnly]
    [SerializeField] private FMVTimedObjectPopup[] popups;
    /// <summary>
    /// A clone of the popups array so we don't modify the 
    /// actual array of the ScriptableObject.
    /// </summary>
    private FMVTimedObjectPopup[] popupsClone;
    /// <summary>
    /// How many popups still need to be instantiated.
    /// </summary>
    private int popupsLength;

    // No choices to be made
    [Tooltip("The scenario to progress to once the current scenario ends.")]
    [HideIf("choicesToBeMade")]
    [SerializeField] private FMVScenarioSO nextScenario;



    /// <summary>
    /// Initializes the current scenario.
    /// </summary>
    public void Init()
    {
        popupsLength = popups.Length;
        popupsClone = popups.Clone() as FMVTimedObjectPopup[];

        timeElapsedChannel.OnEventRaised += TrackTime;
    }

    /// <summary>
    /// Unsubscribes from the time elapsed channel's event.
    /// </summary>
    public void UnInit()
    {
        timeElapsedChannel.OnEventRaised -= TrackTime;
    }

    /// <summary>
    /// Tracks the elapsed time of the current video, and instantiates any popups if
    /// their popup time has been reached.
    /// </summary>
    /// <param name="elapsedTime">The elapsed time in the video.</param>
    private void TrackTime(double elapsedTime)
    {
        Debug.Log("Tracking time!");
        // If there are no popups in the array, 
        // unsubscribe from the event to prevent function calls.
        if (popupsLength <= 0)
        {
            Debug.Log("No more popups... Unsubbing");
            timeElapsedChannel.OnEventRaised -= TrackTime;
            return;
        }

        // Loop through the array of popups and instantiate any
        // that hit their popup time.
        for (int i = 0; i < popupsClone.Length; ++i)
        {
            FMVTimedObjectPopup popup = popupsClone[i];
            if (popup == null)
            {
                continue;
            }

            if (elapsedTime >= popup.PopupTime)
            {
                InstantiatePopup(popup.gameObject);
                popupsClone[i] = null;
                popupsLength--;
            }
        }
    }

    /// <summary>
    /// Instantiates a popup into the world with the game object tagged "VideoParent" as the parent. 
    /// </summary>
    /// <param name="popup">The popup to instantiate.</param>
    private void InstantiatePopup(GameObject popup)
    {
        Transform videoParent = GameObject.FindGameObjectWithTag("VideoParent").transform;
        Instantiate(popup, videoParent);
    }
}