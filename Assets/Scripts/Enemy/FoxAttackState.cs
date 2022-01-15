using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class FoxAttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private FireBall _template;

    private float _elepsedTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _elepsedTime = _delay;
    }

    private void Update()
    {
        if (_elepsedTime >= _delay)
        {
            var fireBall = Instantiate(_template, gameObject.transform.position + _template.transform.position, Quaternion.identity);
            _animator.Play(AnimatorEnemy.State.Attack);
            fireBall.SetTarget(Target);
            _elepsedTime = 0;
        }

        _elepsedTime += Time.deltaTime;
    }
}
