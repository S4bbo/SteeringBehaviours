using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    #region Variables
    // Public
    public Vector3 force;
    public Vector3 velocity;
    public float maxVelocity = 100f;

    // Private
    private List<SteeringBehaviour> behaviours;

    #endregion

    #region Unity Functions
    // Use this for initialization
    void Start()
    {
        // Obtain all Steering Behaviours attached to AI Agent
        behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
    }

    // Update is called once per frame
    void Update()
    {
        ComputeForces();
        ApplyVelocity();
    }

    #endregion

    #region Functions

    void ComputeForces()
    {
        // Reset the Force
        force = Vector3.zero;

        // Loop through all behaviours attached to gameObject
        for (int i = 0; i < behaviours.Count; i++)
        {
            SteeringBehaviour behaviour = behaviours[i];
            if (!behaviour.enabled) continue;

            // Add on force from behaviour
            force += behaviour.GetForce() * behaviour.weighting;

            // If the force is too big
            if (force.magnitude > maxVelocity)
            {
                // Clamp it to the max Velocity
                force = force.normalized * maxVelocity;

                // Break out of loop
                break;
            }
        }
    }

    void ApplyVelocity()
    {
        // Add force to velocity
        velocity += force * Time.deltaTime;

        // If velocity is too high
        if (velocity.magnitude > maxVelocity)
        {
            velocity = velocity.normalized * maxVelocity;
        }

        // Check if velocity is valid
        if (velocity != Vector3.zero)
        {
            Vector3 pos = transform.position;
            pos.x += velocity.x * Time.deltaTime;
            pos.z += velocity.z * Time.deltaTime;
            // Apply position & velocity
            transform.position = pos;
            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }

    #endregion
}
