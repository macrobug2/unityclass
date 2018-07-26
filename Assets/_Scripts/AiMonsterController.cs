using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiMonsterController : MonoBehaviour
{
    private NavMeshAgent agent;

    public float MovementSpeed;
    public float AttackRadius;
    public float AttackCooldown;
    public float SetAttackCooldown;

    public GameObject Target;

    private Rigidbody RB;

    public Animator Anim;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();

        agent = GetComponent<NavMeshAgent>();

        agent.speed = MovementSpeed;
        agent.acceleration = MovementSpeed * 2;
        agent.stoppingDistance = 0;


        agent.SetDestination(Target.transform.position);
    }

    public void updateAnim()
    {
        Vector3 localVel = transform.InverseTransformDirection(agent.velocity);

        Anim.SetFloat("ForwardSpeed", localVel.z);

    }

    // Update is called once per frame
    void Update () {

        updateAnim();
        SetAttackCooldown -= Time.deltaTime;
       
        float DistanceBetween = agent.remainingDistance;

        if(DistanceBetween <= AttackRadius)
        {
            
            agent.isStopped = true;

            if (SetAttackCooldown <= 0)
            {
                Anim.SetTrigger("Attack");
              
            }
        }
        else if(SetAttackCooldown <= 0)
        {
            agent.isStopped = false;
        }
        agent.SetDestination(Target.transform.position);

    }
}
