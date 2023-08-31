using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    [SerializeField] private Transform target;

    void Start()
    {
        GetReferences();
    }

    void Update()
    {
        MoveToTarget();

        transform.LookAt(target);

        Vector3 direction = target.position = transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        Update();
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
}