using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class SteeringBehaviour : MonoBehaviour
{
    #region Variables
    // Public
    public float weighting = 7.5f;
    public Vector3 force;

    [HideInInspector]
    public AIAgent owner;

    #endregion

    #region Unity Functions
    // Make this functions virtual and override it
    // in the sub-classes (Also call base.Awake)
    // Called before Start()
    void Awake()
    {
        owner = GetComponent<AIAgent>();
    }

    #endregion

    #region Sterring Behaviour Functions
    public virtual Vector3 GetForce()
    {
        // Return the force
        return Vector3.zero;
    }

    #endregion
}
