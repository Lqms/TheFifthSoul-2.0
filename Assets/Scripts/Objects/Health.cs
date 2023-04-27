using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField][Range(1, float.MaxValue)] private float _max = 10;

    private float _current;

    public event UnityAction Over;
    public event UnityAction Damaged;

    private void Start()
    {
        _current = _max;
    }

    public void ApplyDamage(float amount)
    {
        _current = Mathf.Clamp(_current - amount, 0, _current);
        Damaged?.Invoke();
        print(_current);

        if (_current == 0)
            Over?.Invoke();
    }
}
