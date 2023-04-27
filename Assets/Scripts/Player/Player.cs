using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event UnityAction Died;

    private void OnEnable()
    {
        _health.Over += OnHealthOver;
    }

    private void OnDisable()
    {
        _health.Over -= OnHealthOver;
    }

    private void OnHealthOver()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
