using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAnimationManager : MonoBehaviour
{
    public AiMonsterController Controller;
    public GameObject attackZone;

    public void StartAttack()
    {
        attackZone.SetActive(true);
    }

    public void EndDamage()
    {
        attackZone.SetActive(false);
    }

    public void EndAttack()
    {
        Controller.SetAttackCooldown = Controller.AttackCooldown;
    }
}
