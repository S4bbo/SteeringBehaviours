using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class AgentDirector : MonoBehaviour
{
    #region Variables
    // Public
    public Transform selectedTarget;
    public float rayDistance = 1000f;
    public LayerMask selectionLayer;

    // Private
    private Vector3 selectedTargetPos;

    #endregion

    #region Unity Functions
    // Update is called once per frame
    void Update()
    {
        CheckSelection();GizmosGL.AddSphere(selectedTargetPos, 5, Quaternion.identity, Color.red);
    }

    #endregion

    void CheckSelection()
    {
        // Create a ray from mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GizmosGL.AddLine(ray.origin, ray.origin + ray.direction * rayDistance);

        // Variable to store hit information
        RaycastHit hit;

        // Perform raycast
        if (Physics.Raycast(ray, out hit, rayDistance, selectionLayer))
        {
            GizmosGL.AddSphere(hit.point, 5f);
            if (Input.GetMouseButtonDown(0))
            {
                // Get selected target
                selectedTarget = hit.collider.transform;
                selectedTargetPos = hit.point;
                ApplySelection();
            }
        }
    }

    void ApplySelection()
    {
        AIAgent[] aiAgents = FindObjectsOfType<AIAgent>();
        for (int i = 0; i < aiAgents.Length; i++)
        {
            AIAgent agent = aiAgents[i];

            // Find a seek behaviour attached
            Seek seek = agent.GetComponent<Seek>();
            SeekPosition seekPos = agent.GetComponent<SeekPosition>();
            if (seek != null)
            {
                // Set it's target to selected target
                seek.target = selectedTarget;
            }

            // If there is a seekposition behaviour attached
            if (seekPos != null)
            {
                // Set it's target to selected target
                seekPos.target = selectedTargetPos;
            }
        }
    }
}
