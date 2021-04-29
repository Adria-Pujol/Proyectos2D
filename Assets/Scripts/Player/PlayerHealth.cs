using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public float health = 7f;
        public float knockback;
        public float invulnerableTotalTime;
        public float invulnerableCurrentTime;
        public bool canRecieveDmg;
        public Transform respawnPosition;

        private Rigidbody2D _body;

        public void Awake()
        {
            invulnerableCurrentTime = invulnerableTotalTime;
            _body = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            if (invulnerableCurrentTime < invulnerableTotalTime)
                invulnerableCurrentTime += Time.deltaTime;
            else
                canRecieveDmg = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy")) return;
            if (canRecieveDmg)
            {
                health -= 1;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
                _body.AddForce(new Vector2(-knockback * 20, knockback));
            }

            if (health <= 0) Death();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy")) invulnerableCurrentTime += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy")) return;
            if (canRecieveDmg)
            {
                health -= 1;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
                _body.AddForce(new Vector2(-knockback * 20, knockback));
            }
            else
            {
                invulnerableCurrentTime += Time.deltaTime;
            }

            if (health <= 0) Death();
        }

        public void TakeDamage(float dmg)
        {
            if (canRecieveDmg)
            {
                health -= dmg;
                invulnerableCurrentTime = 0f;
                canRecieveDmg = false;
            }

            if (health <= 0) Death();
        }

        private void Death()
        {
            gameObject.transform.position = respawnPosition.position;
            gameObject.GetComponent<PlayerController>().isDead = true;
            health = 7f;
        }
    }
}