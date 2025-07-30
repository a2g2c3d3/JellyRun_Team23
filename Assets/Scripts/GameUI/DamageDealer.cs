using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // 충돌 시 대미지

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 충돌 시 대미지를 주고 자신은 파괴
        if (other.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
