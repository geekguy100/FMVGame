/*****************************************************************************
// File Name :         VoidChannelSO.cs
// Author :            Kyle Grenier
// Creation Date :     09/16/2021
//
// Brief Description : A channel that receives subscribes and broadcasts a Void event.
*****************************************************************************/
using UnityEngine;
using UnityEngine.Events;

public class VoidChannelSO : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}