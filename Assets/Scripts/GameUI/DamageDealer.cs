using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // �浹 �� �����

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾�� �浹 �� ������� �ְ� �ڽ��� �ı�
        if (other.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
