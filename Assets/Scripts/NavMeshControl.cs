using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshControl : MonoBehaviour
{
    

    [SerializeField]
    private string TargetTag;

    [SerializeField]
    private float attackRange = 10f;
   

    private Transform target;
    private Transform player;
    private Transform _trans;
    private NavMeshAgent myNavMesh;

   

    public bool _angry { get; private set; }

    private Vector3 lastRotation;

    Vector3 GetAngularVelocity
    {
        get
        {
            return lastRotation - _trans.rotation.eulerAngles;
        }
    }

    void Start()
    {
        lastRotation = _trans.rotation.eulerAngles;
        ApplyTarget(target);
    }

     void Awake()
    {
        _trans = GetComponent<Transform>();
        myNavMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag(TargetTag).transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        float nearPlayer = (transform.position - player.position).magnitude;
        if(nearPlayer < attackRange || _angry)
        {
            target = player;
            ApplyTarget(player);
        }
        else
        {
            ApplyTarget(target);
        }
        if (GetAngularVelocity.magnitude > 0.3f)
        {
            myNavMesh.speed = 0.5f;
            myNavMesh.acceleration = 1;
        }
        else
        {
            myNavMesh.speed = 1;
            myNavMesh.acceleration = 10;
        }
        lastRotation = _trans.rotation.eulerAngles;
        
        if(nearPlayer > attackRange * 2)
        {
            StayAngry(false);
        }

       /* float nearPlayer = (transform.position - player.position).magnitude;
        if(nearPlayer < attackRange)
        {
            ApplyTarget(player);
        }
        else
        {
            ApplyTarget(target);
        }
        */
    }
    void ApplyTarget(Transform targetTrans)
    {
        if(targetTrans != null)
        {
            myNavMesh.SetDestination(targetTrans.position);
        }
    }

    public void StayAngry(bool angryState)
    {
        _angry = angryState;
    }
}
