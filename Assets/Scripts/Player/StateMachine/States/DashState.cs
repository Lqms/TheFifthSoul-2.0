using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _dashPower = 10;
    [SerializeField] private Player _player;

    protected override void OnEnable()
    {
        base.OnEnable();

        Dash();
    }

    private void Dash()
    {
        StartCoroutine(Dashing());
        _player.StartReloadingDash();
    }

    private IEnumerator Dashing()
    {
        _rigidbody.AddForce(Vector2.right * transform.parent.localScale.x * _dashPower, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.1f);

        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}
