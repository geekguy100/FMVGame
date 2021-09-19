/*****************************************************************************
// File Name :         FMVScenarioProgressor.cs
// Author :            Kyle Grenier
// Creation Date :     09/16/2021
//
// Brief Description : Progresses to another scenario when called upon.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

[DisallowMultipleComponent]
public class FMVScenarioProgressor : MonoBehaviour
{
    [Tooltip("The channel to raise an event to to signal a change in scenarios.")]
    [HideIf("IsSet")]
    [SerializeField] private FMVScenarioChannelSO scenarioProgressorChannel;

    [Tooltip("The scenario this progressor leads into.")]
    [SerializeField] private FMVScenarioSO nextScenario;

    /// <summary>
    /// Requests to progress to the next scenario provided.
    /// </summary>
    public void ProgressScenario()
    {
        scenarioProgressorChannel.RaiseEvent(nextScenario);
    }

    private bool IsSet()
    {
        return scenarioProgressorChannel != null;
    }
}