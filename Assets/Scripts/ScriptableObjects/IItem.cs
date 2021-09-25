/*****************************************************************************
// File Name :         IItem.cs
// Author :            Kyle Grenier
// Creation Date :     09/25/2021
//
// Brief Description : Defines an interface that all inventory- 
                       system-compatible items must derive from.
*****************************************************************************/
using UnityEngine;

/// <summary>
/// Defines an iterface that all inventory 
/// system compatible items must derive from.
/// </summary>
public abstract class IItem : ScriptableObject
{
    /// <summary>
    /// Returns the name of the item.
    /// </summary>
    /// <returns>The name of the item.</returns>
    public abstract string GetName();
}