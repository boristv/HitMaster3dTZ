using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Animator _animator;

    private List<Rigidbody> rbParts = new List<Rigidbody>();

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        SetRigidbodyFromRagdollParts();
    }


    private void SetRigidbodyFromRagdollParts()
    {
        Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rbParts.Add(rb);
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }
    
    public void TurnOnRagdoll()
    {
        foreach (var rb in rbParts)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        _animator.enabled = false;
    }
}
