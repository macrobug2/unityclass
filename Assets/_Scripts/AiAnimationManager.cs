using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAnimationManager : MonoBehaviour
{
    public AiMonsterController Controller;

    public void StartAttack() { }
    public void EndDamage() { }
    public void EndAttack()
    {
        Controller.SetAttackCooldown = Controller.AttackCooldown;
    }
}
