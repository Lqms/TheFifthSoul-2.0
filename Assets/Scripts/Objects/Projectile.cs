using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private float _damage;

    public void Init(Vector2 position, Vector2 direction, float shotPower)
    {
        _damage = shotPower;
        transform.position = position;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.velocity = direction * shotPower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);

        if (collision.TryGetComponent(out Health health))
        {
            health.ApplyDamage(_damage);
        }

        Destroy(gameObject);
    }
}
