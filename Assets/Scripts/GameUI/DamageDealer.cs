using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
