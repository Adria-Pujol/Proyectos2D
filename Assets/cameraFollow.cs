using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] [Range (0, 10)] float smoothFactor;

    private Vector2 _targetPosition;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Follow();
    }


    void Follow()
    {

        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
