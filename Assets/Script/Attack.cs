using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 10;
    public string targetTag; // e.g. "Enemy" for player, "Player" for enemy
    public float attackCooldown = 1f;
    private float lastAttackTime = -999f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        if (other.CompareTag(targetTag))
        {
            Health targetHealth = other.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}
