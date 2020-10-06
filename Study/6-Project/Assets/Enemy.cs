using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

// Navigation 관련 기능을 사용할 때 필요.
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private float sightLevel = 0.4f; // radian
    [SerializeField] private float sightLenth = 4.0f; // meter
    [SerializeField] private float attackRange = 1.5f; // meter
    [SerializeField] private float attackRate = 0.5f; // fps
    [SerializeField] private float attackPower = 1.0f;

    [SerializeField] private LayerMask layerToCast;
    [SerializeField] private Status status;

    private NavMeshAgent _agent;
    private Player _player;
    private EnemyState _state;
    private float _attackTimer;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        gameObject.SetActive(true);

        _state = EnemyState.Idle;

        StartCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        while (_state != EnemyState.Dead)
        {

            switch (_state)
            {
                case EnemyState.Idle:
                    Idle();
                    break;
                case EnemyState.Dead:
                    Dead();
                    break;
                case EnemyState.Search:
                    Search();
                    break;
                case EnemyState.Chase:
                    Chase();
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
            }

            if(GameManager.Instance.State == KPU.State.GameEnded)
            {
                _state = EnemyState.Dead;
                break;
            }

            // yield return null: 1 Frame에 한번씩 루틴문을 실행하도록 할 수 있다.
            yield return null;
        }

        // Dead
        gameObject.SetActive(false);
    }

    private void Idle()
    {
        _state = EnemyState.Search;
    }
    private void Dead()
    {
        return;
    }

    private void Search()
    {
        // 시야각 로직
        var dir = (_player.transform.position - transform.position).normalized;
        var dot = Vector3.Dot(transform.forward, dir);

        if (dot > sightLevel)
        {
            if (Physics.Raycast(transform.position, dir, out var raycastHit, sightLenth, layerToCast))
            {
                var hitObject = raycastHit.collider.gameObject;
                if (hitObject.CompareTag("Player"))
                {
                    _state = EnemyState.Chase;
                }
            }
        }
    }

    private void Chase()
    {
        _agent.isStopped = false;

        var dist = (_player.transform.position - transform.position).magnitude;
        if (dist < attackRange)
            _state = EnemyState.Attack;
        else
            _agent.SetDestination(_player.transform.position);
    }

    private void Attack()
    {
        _agent.isStopped = true;

        var dist = (_player.transform.position - transform.position).magnitude;
        if (dist >= attackRange)
        {
            _state = EnemyState.Idle;
        }
        else
        {
            if (_attackTimer > attackRate)
            {
                _player.Damage(attackPower);
                _attackTimer = 0.0f;
            }
            else _attackTimer += Time.deltaTime;
        }
    }

    public void Damage(float damageAmount)
    {
        status.currentHp = Mathf.Clamp(status.currentHp - damageAmount, 0.0f, status.MaxHp);

        if (status.currentHp <= 0.0f)
            _state = EnemyState.Dead;
    }
}

