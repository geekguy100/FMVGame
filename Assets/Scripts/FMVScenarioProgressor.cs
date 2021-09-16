/*****************************************************************************
// File Name :         FMVScenarioProgressor.cs
// Author :            Kyle Grenier
// Creation Date :     09/16/2021
//
// Brief Description : Progresses to another scenario when called upon.
*****************************************************************************/
using UnityEngine;

public class FMVScenarioProgressor : MonoBehaviour
{
    [Tooltip("The scenario to lead into.")]
    [SerializeField] private FMVScenarioSO nextScenario;
    /// <summary>
    /// The scenario to lead into.
    /// </summary>
    public FMVScenarioSO NextScenario
    {
        get
        {
            return nextScenario;
        }
    }
}