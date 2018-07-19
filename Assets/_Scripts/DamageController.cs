using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public float DamageAmmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.name);
        var health = other.GetComponent<HealthController>();
        if (health != null && other.CompareTag("Player"))
        {
            health.TakeDamage(DamageAmmount);
        }
    }
}
