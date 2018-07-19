using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    public float AttackRate = .1f;

    private float SetAttackDelay;

    public void Attack(Animator Anim)
    {
        if (SetAttackDelay == 0)
        {
            Debug.Log("ATTACK!");
            Anim.SetTrigger("Attack");
            SetAttackDelay = AttackRate;
        }
    }

    void Update()
    {
        SetAttackDelay = Mathf.Max(0, SetAttackDelay - Time.deltaTime);
    }
}
