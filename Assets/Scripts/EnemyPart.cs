using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private float multiplier = 1f;
    [SerializeField] private EnemyHealth enemyHealth;

    public void ApplyDamage(float damage)
    {
        enemyHealth.ApplyDamage(damage * multiplier);
    }
}
