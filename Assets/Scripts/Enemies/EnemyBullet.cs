using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 20f;

        [SerializeField] private float bulletDamage = 1f;

        [SerializeField] private Rigidbody2D body;

        [SerializeField] private float timeAlive = 1.5f;

        [SerializeField] private float timeAliveFromCollision;

        [SerializeField] public GameObject weapon;

        public LayerMask groundLayer;
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
            if (collision.CompareTag("Player"))
            {
                var playerHp = collision.GetComponent<PlayerHealth>();
                var player = collision.GetComponent<PlayerController>();

                if (playerHp != null)
                {
                    playerHp.TakeDamage(bulletDamage);
                    player.MakeConfusion();
                }

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