using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMonsterController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody RB;
    private MeleeController melee;

    public float MovementSpeed;
    public float AttackRadius;
    public GameObject target;
    public Animator Anim;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        melee = GetComponent<MeleeController>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = MovementSpeed;
        agent.acceleration = MovementSpeed * 2;
        agent.stoppingDistance = 0;
    }

    void Update()
    {
        updateAnim();
        updateDestination();
        updateAttack();
    }

    public void updateDestination()
    {
        agent.SetDestination(target.transform.position);
        agent.isStopped = agent.remainingDistance <= AttackRadius;
    }

    public void updateAttack()
    {
        if (agent.remainingDistance <= AttackRadius)
        {
            melee.Attack(Anim);
        }
    }

    public void updateAnim()
    {
        Vector3 localVel = transform.InverseTransformDirection(agent.velocity);

        Anim.SetFloat("ForwardSpeed", localVel.z);
    }
}
