using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class PatrolPoints : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private string _targetTag;
    [SerializeField] private float _distanceForPursuit;

    private float DistanceForPursuitSQR => _distanceForPursuit * _distanceForPursuit;
    private int _CurrentWaypointIndex;
    private GameObject _target;
    private bool _isInPursuit = false;
    [SerializeField] private string _animationName;
    private Animator _Animator;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag(_targetTag);
    }
    void Start()
    {
        _navMeshAgent.SetDestination(_waypoints[0].position);
        _Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (IsTargetTooClose() && !IsHaveObstacleBetween())
        {
            _isInPursuit = true;
        }
        else
        {
            _isInPursuit = false;
           if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
            }
        }
    }
    void LateUpdate()
    {
        if (_isInPursuit)
        {
            _navMeshAgent.SetDestination(_target.transform.position);
        }
        else
        {

            var isCorrectDestinationInWaypoints =
            (from t in _waypoints
             where t.position == _navMeshAgent.destination
             select t.position).Count() == 1;

            if (!isCorrectDestinationInWaypoints)
            {
                WalkAnimation(true);
                _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
            }

            else if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                WalkAnimation(true);
                _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
                
            }
        }
    }

    private void WalkAnimation(bool tof)
    {
        _Animator.SetBool(_animationName, tof);
    }
    private bool IsHaveObstacleBetween()
    {
        var hitDirection = (_target.transform.position - transform.position).normalized;
        var realDistance = _distanceForPursuit;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, hitDirection, out hit, _distanceForPursuit))
        {
            realDistance = hit.distance;
        }

        if (hit.transform.tag == _targetTag) return false;

        return true;
    }

    private bool IsTargetTooClose()
    {
        var distanceFromBotToTargetSQR = (_target.transform.position - transform.position).sqrMagnitude;

        if (distanceFromBotToTargetSQR > DistanceForPursuitSQR)
            return false;

        return true;
    }
}
