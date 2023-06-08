using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max = 10;
    [SerializeField] private AudioClip _damageSFX;
    [SerializeField] private ParticleSystem _damageVFX;

    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;
    private float _current;
    private ParticleSystem _currentParticle;

    public float Current => _current;

    public event UnityAction Over;
    public event UnityAction Damaged;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _current = _max;
    }

    public void ApplyDamage(float amount)
    {
        _current = Mathf.Clamp(_current - amount, 0, _current);

        StartCoroutine(ColorChanging());
        _audioSource.PlayOneShot(_damageSFX);

        Damaged?.Invoke();

        if (_current == 0)
            Over?.Invoke();
    }

    IEnumerator ColorChanging()
    { 
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
    }

    private void SpawnDamagePErticles()
    {
        _currentParticle = Instantiate(_damageVFX, transform.position, Quaternion.identity);
    }
}
