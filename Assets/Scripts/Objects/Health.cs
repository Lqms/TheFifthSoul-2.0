using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max = 10;
    [SerializeField] private AudioClip _damageSFX;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private float _current;

    public float Current => _current;

    public event UnityAction Over;
    public event UnityAction Damaged;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _current = _max;
    }

    public void ApplyDamage(float amount, Vector2 pushDirection)
    {
        _current = Mathf.Clamp(_current - amount, 0, _current);
        Damaged?.Invoke();
        print(_current);
        StartCoroutine(ColorChanging());
        _audioSource.PlayOneShot(_damageSFX);
        _rigidbody.AddForce((Vector2.up + pushDirection) * 10, ForceMode2D.Impulse);

        if (_current == 0)
            Over?.Invoke();
    }

    IEnumerator ColorChanging()
    { 
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
    }
}
