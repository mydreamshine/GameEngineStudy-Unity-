using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1.0f;

    private void OnEnable()
    {
        Invoke("Hide", 3.0f);
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enmey"))
        {
            var damagable = other.gameObject.GetComponent<IDamagable>();
            if(damagable != null)
                damagable.Damage(damage);

            gameObject.SetActive(false);
        }
    }
}
