﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody RB;

    public float WalkAcclerationSpeed; // How fast we speed up
    public float SprintAcclerationSpeed; // How fast we speed up

    private float SetAccelerationSpeed;

    public float MaxWalkSpeed; // Max speed while walking
    public float MaxSprintSpeed; // max speed while sprinting

    private float SetMaxSpeed; //actual private variable that we use to clamp the speed

    public float RotateSpeed;

    public Animator Anim; // Animator

    private Vector3 IP; //Input vector

    private Camera cam;

    public GunController Gun;
    public HealthComponent Health;

    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        //GunController = GetComponent<GunController>();

        RB = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0;

        cam = GameObject.FindObjectOfType<Camera>();
        if (cam == null)
        {
            Debug.Log("NO CAMERA");
        }
    }

    public void updateAnim()
    {
        //Vector3 localVel = transform.InverseTransformDirection(agent.velocity);

        //Anim.SetFloat("Blend", localVel.z);
        //Anim.SetFloat("HorizontalSpeed", localVel.x);

        float velocity = agent.velocity.magnitude / MaxSprintSpeed;
        Debug.Log(velocity);
        Anim.SetFloat("Blend", velocity);
    }

    // vel / maxspeed

    public void keyInput()
    {
        //IP.x = Input.GetAxisRaw("Horizontal");
        //IP.z = Input.GetAxisRaw("Vertical");

        SetMaxSpeed = (Input.GetButton("Sprint")) ? MaxSprintSpeed : MaxWalkSpeed;
        agent.speed = SetMaxSpeed;

        SetAccelerationSpeed = (Input.GetButton("Sprint")) ? SprintAcclerationSpeed : WalkAcclerationSpeed;
        agent.acceleration = SetAccelerationSpeed;

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<AiMonsterController>().SelectedGround.SetActive(true);
                }
                agent.SetDestination(hit.point);
            }
        }
    }

    //public void handleMovement()
    //{

    //    RB.AddForce(IP * Time.deltaTime * SetAccelerationSpeed);

    //    RB.velocity = new Vector3(Mathf.Clamp(RB.velocity.x, -SetMaxSpeed, SetMaxSpeed),
    //                              RB.velocity.y,
    //                              Mathf.Clamp(RB.velocity.z, -SetMaxSpeed, SetMaxSpeed));
    //}

    public void doMouseLook()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000))
        {
            Vector3 forward = (transform.position - hit.point).normalized * -1;
            transform.forward = Vector3.MoveTowards(transform.forward, forward, RotateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        keyInput();
    }

    private void FixedUpdate()
    {
        //handleMovement();
        updateAnim();
        doMouseLook();
    }
}
