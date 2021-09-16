/*****************************************************************************
// File Name :         FMVScenarioProgressor.cs
// Author :            Kyle Grenier
// Creation Date :     09/16/2021
//
// Brief Description : Progresses to another scenario when called upon.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class FMVScenarioProgressor : MonoBehaviour
{
    [SerializeField] private FMVScenarioProgressorData data;

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    private void OnEnable()
    {
        // If this ScenarioProgressor is a Button, automatically add the onClick event
        // so we don't have to do it every time in the inspector.
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(ProgressScenario);
        }
    }


    /// <summary>
    /// Requests to progress the scenario to the provided one.
    /// </summary>
    public void ProgressScenario()
    {
        data.RequestScenarioProgression();
    }
}