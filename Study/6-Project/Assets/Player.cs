using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

// Navigation 관련 기능을 사용할 때 필요.
using UnityEngine.AI;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed;
    [SerializeField] private Status status;
    [SerializeField] private float attackPower = 1.0f;
    [SerializeField] private float attackRate = 0.25f;
    [SerializeField] private float shootSpeed = 20f; // N

    private PlayerState _state;
    private NavMeshAgent _agent;

    private float attackTimer;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _state = PlayerState.Idle;
        status.currentHp = status.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == KPU.State.GameEnded) return;

        var dir = (cam.transform.forward * Input.GetAxis("Vertical") + cam.transform.right * Input.GetAxis("Horizontal")).normalized;
        print(dir);

        _agent.Move(new Vector3(dir.x, 0, dir.z) * (Time.deltaTime * speed));

        // 회전
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));

        // shoot
        {
            if (attackTimer >= attackRate)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    var bulletGmaeObject = ObjectPoolManager.Instance.Spawn("blluet", transform.position);
                    var rigidBody = bulletGmaeObject.GetComponent<Rigidbody>();

                    // Impulse: 충격량
                    rigidBody.AddForce(transform.forward * shootSpeed, ForceMode.Impulse);
                }
                attackTimer = 0.0f;
            }
            else attackTimer += Time.deltaTime;
        }
    }

    public void Damage(float damageAmount)
    {
        status.currentHp = Mathf.Clamp(status.currentHp - damageAmount, 0.0f, status.MaxHp);

        if (status.currentHp <= 0.0f)
        {
            _state = PlayerState.Dead;
            EventManager.Emit("game_over");
            EventManager.Emit("game_ended");
        }
    }
}
