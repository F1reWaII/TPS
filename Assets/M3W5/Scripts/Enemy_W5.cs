using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_W5 : MonoBehaviour
{
    public List<Transform> PatrolPoints;
    public Transform Player;
    public float ViewAngle = 90;
    public float MinDetectDistance = 3;
    public float damage = 200;
    private float _timer;

    private PlayerHealth _playerHealth;

    NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth= Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (CheckPlayer())
        {
            _navMeshAgent.SetDestination(Player.position);
        }
        else
        {
            Patrol();
        }

        AttackUpdate();

    }

    void AttackUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.DealDamaged(damage * Time.deltaTime);
        }
    }

    bool CheckPlayer()
    {
        Vector3 direction = Player.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle || Vector3.Distance(transform.position, Player.position) < MinDetectDistance)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.transform == Player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Patrol()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
        }
    }
}
