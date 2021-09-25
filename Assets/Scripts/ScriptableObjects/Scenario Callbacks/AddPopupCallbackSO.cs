/*****************************************************************************
// File Name :         AddPopupCallbackSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/25/2021
//
// Brief Description : Adds an item to the Scenario's popup list if a condition is met.
*****************************************************************************/
using UnityEngine;

[CreateAssetMenu(menuName = "FMV Maker/Scenarios/Callbacks/Add Popup", fileName = "New Add Popup Callback")]
public class AddPopupCallbackSO : ScenarioCallbackSO
{
    private enum AddPopupCondition { NONE, REQUIRE_INVENTORY_ITEM };
    [SerializeField] private AddPopupCondition condition = AddPopupCondition.NONE;

    /// <summary>
    /// Adds a popup to the Scenario based on the set condition.
    /// </summary>
    /// <param name="scenario">The Scenario which invoked this callback.</param>
    public override void PerformCallback(FMVScenarioSO scenario)
    {
        throw new System.NotImplementedException();
    }
}