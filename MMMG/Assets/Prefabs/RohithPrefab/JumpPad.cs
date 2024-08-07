using UnityEngine;
using System.Collections.Generic;

public class JumpPad : MonoBehaviour
{
    [Header("Jump Settings")]
    [Tooltip("The jump force to be applied when an eligible object collides with the jump pad.")]
    public float jumpForce = 10f;

    [Header("Eligible Objects")]
    [Tooltip("List of GameObjects that can interact with the jump pad.")]
    public List<GameObject> eligibleObjects;

    private void OnTriggerEnter(Collider other)
    {
        if (IsEligibleForJump(other.gameObject))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }
    }

    private bool IsEligibleForJump(GameObject obj)
    {
        return eligibleObjects.Contains(obj);
    }
}
