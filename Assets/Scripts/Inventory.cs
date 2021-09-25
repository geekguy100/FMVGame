/*****************************************************************************
// File Name :         Inventory.cs
// Author :            Kyle Grenier
// Creation Date :     09/25/2021
//
// Brief Description : Holds any items that the player collects during the game.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

/// <summary>
/// Holds any items that the player collects during the game.
/// </summary>
public class Inventory : MonoBehaviour
{
    [Tooltip("The items being held in this inventory.")]
    [ReadOnly][SerializeField] private List<IItem> items;

    /// <summary>
    /// Initializing the list.
    /// </summary>
    private void Awake()
    {
        items = new List<IItem>();
    }

    /// <summary>
    /// Returns true if the inventory contains the item.
    /// </summary>
    /// <param name="item">The item to check the inventory for.</param>
    /// <returns>True if the inventory contains the item.</returns>
    public bool HasItem(IItem item)
    {
        return items.Contains(item);
    }
}