using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantAnimations : MonoBehaviour
{
    #region Variables
    // Public

    // Private
    private Animator anim;
    private Vector3 prevPos;

    #endregion

    #region
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = prevPos - transform.position;
        anim.SetFloat("moveSpeed", Mathf.Abs(displacement.magnitude));
        prevPos = transform.position;
    }

    #endregion
}
