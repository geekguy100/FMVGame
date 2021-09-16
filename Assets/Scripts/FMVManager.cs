/*****************************************************************************
// File Name :         FMVManager.cs
// Author :            Kyle Grenier
// Creation Date :     09/16/2021
//
// Brief Description : Controls the flow of the FMV.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using Sirenix.OdinInspector;

public class FMVManager : MonoBehaviour
{
    [Tooltip("The scenario to play.")]
    [Required("A starting scenario is required.")]
    [SerializeField] private FMVScenarioSO currentScenario;

    [Tooltip("The VideoPlayer that plays the current scenario's video.")]
    [Required("A reference to the VideoPlayer is required.")]
    [SerializeField] private VideoPlayer videoParent;

    [Tooltip("Channel to broadcast the time elapsed to.")]
    [SerializeField] private DoubleChannelSO elapsedTimeChannel;
   

    private void Start()
    {
        SwapScenario(currentScenario);
        PlayCurrentScenario();
    }

    /// <summary>
    /// Plays the current scenario.
    /// </summary>
    public void PlayCurrentScenario()
    {
        if(!videoParent.isPlaying)
        {
            videoParent.Play();
            StartCoroutine(TrackTime());
        }
    }

    /// <summary>
    /// Stops the current scenario.
    /// </summary>
    public void StopCurrentScenario()
    {
        videoParent.Stop();
        StopAllCoroutines();
    }

    /// <summary>
    /// Swaps the current scenario with the provided scenario.
    /// </summary>
    /// <param name="scenario">The scenario to swap to.</param>
    public void SwapScenario(FMVScenarioSO scenario)
    {
        StopCurrentScenario();

        currentScenario.UnInit();
        currentScenario = scenario;
        currentScenario.Init();

        videoParent.clip = currentScenario.VideoClip;
    }

    /// <summary>
    /// Broadcasts the elapsed time in the video as an event.
    /// </summary>
    private IEnumerator TrackTime()
    {
        while(true)
        {
            elapsedTimeChannel.RaiseEvent(videoParent.time);
            yield return null;
        }
    }
}