using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        EventManager.Subscribe("game_ended", OnGameEnd);
    }

    private void OnGameEnd(object obj)
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.state != GameState.Playing)
        {
            _rigidbody2D.velocity = Vector2.zero;
            return;
        }
        
        var colliders = new Collider2D[4];
        Physics2D.OverlapCircleNonAlloc(transform.position, 20.0f, colliders);
        var exist_colliders = colliders.Where(collider => collider != null); 
        
        // Aggregate
        // Aggregate는 사용자가 직접 해당 데이터들을 어떻게 가공할지 명시 할 수 있다.
        // 첫번째 인자와 두번째 인자를 연산, 다시 첫번재 인자에 놓고 다시 그다음 번째 인자를 두번째 인자로 놓고 연산을 반복한다.
        // 람다와 재귀가 혼합된 형태와 유사
        var target = exist_colliders.Aggregate((col1, col2) =>
        {
            var magnitude1 = (col1.transform.position - this.transform.position).magnitude;
            var magnitude2 = (col2.transform.position - this.transform.position).magnitude;

            return magnitude1 < magnitude2 ? col1 : col2;
        });

        if (target != null)
        {
            var dir = (target.transform.position - this.transform.position).normalized;
            _rigidbody2D.AddForce(dir * speed);
        }
    }
}
