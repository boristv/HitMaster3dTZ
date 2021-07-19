using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float healthCount;

    public UnityAction<float> OnHealthChanged;

    [SerializeField] private Ragdoll ragdoll;

    private bool died;
    
    private void Awake()
    {
        healthCount = maxHealth;
        EnemyCounter.Count++;
    }

    public void ApplyDamage(float damage)
    {
        if (died) return;
        healthCount -= damage;
        if (healthCount < 0) healthCount = 0;
        OnHealthChanged?.Invoke(healthCount/maxHealth);
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (healthCount <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        transform.parent = null;
        EnemyCounter.Count--;
        died = true;
        ragdoll.TurnOnRagdoll();
        Destroy(gameObject, 5);
    }
}
