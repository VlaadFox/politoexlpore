using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentRandomPosition : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;

    private Animator _animator;
    private float _inputSpeed;
    private Vector3 _inputVector;

    private NavMeshAgent _navMeshAgent;
    private Renderer _renderer;
    private Color _originalColor;
    private float _currentPathTotalDistance = -1f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        SetDestination();
    }

    void Update()
    {
        if (DestinationReached())
            SetDestination();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _inputVector = new Vector3(h, 0, v);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);

        UpdateAnimations();

    }

    private void SetDestination()
    {
        NavMeshPath path = new NavMeshPath();
        Vector3 randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();

        while (!_navMeshAgent.CalculatePath(randomPosition, path))
        {
            randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();
        }

        _navMeshAgent.SetDestination(randomPosition);
        StartCoroutine(WaitForPathTotalDistance());
    }

    private bool DestinationReached()
    {
        if (!_navMeshAgent.pathPending)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude <= 0f)
                    return true;

        return false;
    }

    private IEnumerator WaitForPathTotalDistance()
    {
        _currentPathTotalDistance = -1f;
        _renderer.material.color = _originalColor;
        while (_navMeshAgent.remainingDistance >= Mathf.Infinity || _navMeshAgent.remainingDistance <= 0f)
        {
            yield return null;
        }

        _navMeshAgent.isStopped = false;
        _currentPathTotalDistance = _navMeshAgent.remainingDistance;
    }

    private void UpdateAnimations()
    {
        _animator.SetFloat("speed", _inputSpeed);
    }
}
