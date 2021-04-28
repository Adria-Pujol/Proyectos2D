using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask wallLayer;

    public bool isGrounded;
    public bool isTopWalled;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = collision != null && (((1 << collision.gameObject.layer) & groundLayer) != 0);
        isTopWalled = collision != null && (((1 << collision.gameObject.layer) & wallLayer) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        isTopWalled = false;
    }
}
