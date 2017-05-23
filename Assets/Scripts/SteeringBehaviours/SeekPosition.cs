using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPosition : SteeringBehaviour
{
    #region Variables
    // Public
    public Vector3 target;
    public float stoppingDistance = 0;

    // Private

    #endregion

    public override Vector3 GetForce()
    {
        // Create a new force to calculate
        Vector3 force = Vector3.zero;

        // If there is no target, return force
        if (target == Vector3.zero) return force;

        // Otherwise, calculate a desired velocity
        Vector3 desiredVelocity;

        // Get direction from target to agent
        Vector3 direction = target - transform.position;
        direction.y = 0; // Cancel out y forces

        // Check if the direction is valid
        if (direction.magnitude > stoppingDistance)
        {
            // Calculate the force
            desiredVelocity = direction.normalized * weighting;

            // Apply to force
            force += desiredVelocity - owner.velocity;
        }
        return force;
    }
}
