/*****************************************************************************
// File Name :         FMVTimedObjectPopup.cs
// Author :            Kyle Grenier
// Creation Date :     09/16/2021
//
// Brief Description : A script that holds a time to wait until the attached game object
                       is instantiated.
*****************************************************************************/
using UnityEngine;

public class FMVTimedObjectPopup : MonoBehaviour
{
    [Tooltip("The amount of time to wait before instantiating the GameObject.")]
    [SerializeField] protected double popupTime;
    /// <summary>
    /// The amount of time to wait before instantiating the GameObject.
    /// </summary>
    public double PopupTime
    {
        get
        {
            return popupTime;
        }
    }
}