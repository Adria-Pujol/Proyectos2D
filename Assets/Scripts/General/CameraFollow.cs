using UnityEngine;

namespace General
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] [Range(0, 10)] private float smoothFactor;

        private Vector2 _targetPosition;

        // Update is called once per frame
        private void FixedUpdate()
        {
            Follow();
        }

        private void Follow()
        {
            var targetPosition = target.position + offset;
            var smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
    }
}