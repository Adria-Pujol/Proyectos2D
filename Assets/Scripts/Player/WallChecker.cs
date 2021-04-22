using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask wallLayer;
    
    public bool isWall;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isWall = collision != null && (((1 << collision.gameObject.layer) & wallLayer) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isWall = false;
    }
}
