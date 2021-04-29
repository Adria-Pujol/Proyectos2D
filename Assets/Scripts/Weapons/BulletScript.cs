using Enemies;
using UnityEngine;

namespace Weapons
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 20f;

        [SerializeField] private float bulletDamage = 20f;

        [SerializeField] private Rigidbody2D body;

        [SerializeField] private float timeAlive = 5f;

        [SerializeField] private float timeAliveFromCollision;

        private float _timer;
        private float _timerCollision;

        private void Start()
        {
            _timer = timeAlive;
            _timerCollision = timeAliveFromCollision;
        }

        private void FixedUpdate()
        {
            if (gameObject.activeInHierarchy) body.velocity = transform.right * bulletSpeed;
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                gameObject.SetActive(false);
                _timer = timeAlive;
            }
        }

        private void OnEnable()
        {
            body.velocity = transform.right * bulletSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                var enemy = collision.GetComponent<Enemy>();

                if (enemy != null) enemy.TakeDamage(bulletDamage);
                gameObject.SetActive(false);
            }

            if (collision.CompareTag("Ground")) gameObject.SetActive(false);

            if (!collision.CompareTag("Object")) return;
            if (_timerCollision > 0)
            {
                _timerCollision -= Time.deltaTime;
            }
            else
            {
                gameObject.SetActive(false);
                _timerCollision = timeAliveFromCollision;
            }
        }
    }
}