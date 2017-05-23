using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehaviour
{
    #region Variables
    // Public
    public Transform target;
    public float safeDistance = 10f;

    // Private

    #endregion

    public override Vector3 GetForce()
    {
        // Create a new force to calculate
        Vector3 force = Vector3.zero;

        // If there is no target, return force
        if (target == null) return force;

        // Otherwise, calculate a desired velocity
        Vector3 desiredVelocity;

        // Get direction from target to agent
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // Cancel out y forces

        // Check if the direction is valid
        if (direction.magnitude > safeDistance)
        {
            // Calculate the force
            desiredVelocity = direction.normalized * weighting;

            // Apply to force
            force -= desiredVelocity - owner.velocity;
        }
        return force;
    }
}
