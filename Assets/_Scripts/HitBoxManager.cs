using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour
{
    public float DamageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.name);
        var health = other.GetComponent<HealthComponent>();
        if (health != null && other.CompareTag("Player"))
        {
            health.TakeDamage(DamageAmount);
        }
    }
}
