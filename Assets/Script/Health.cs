using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int damagePerHit = 1;

    public int MaxHealth => maxHealth;
    public int CurrentHealth { get; private set; }

    [SerializeField] private GameObject healthBarPrefab;
    private GameObject healthBarInstance;

    void Start()
    {
        CurrentHealth = maxHealth;

        if (healthBarPrefab != null)
        {
            healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity, transform);
        }
    }

    public void TakeDamage()
    {
        CurrentHealth -= damagePerHit;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (healthBarInstance != null)
            Destroy(healthBarInstance);

        gameObject.SetActive(false); // 或者 Destroy(gameObject);
    }
}
