using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Over += OnHealthOver;
        _health.Damaged += OnHealthDamaged;
    }

    private void OnDisable()
    {
        _health.Over -= OnHealthOver;
        _health.Damaged -= OnHealthDamaged;
    }

    private void OnHealthDamaged()
    {
        // GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20, ForceMode2D.Impulse);
    }

    private void OnHealthOver()
    {
        Destroy(gameObject);
    }
}
