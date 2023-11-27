using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float timeAttackCooldown = 0.9f;
    public int damage = 10;
    
    private float _activeTimeAttackCooldown;
    private Animator _animator;

    private List<IEssence> _essences = new();

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _activeTimeAttackCooldown = timeAttackCooldown;
    }

    private void Update()
    {
        _activeTimeAttackCooldown -= Time.deltaTime;
        if (_activeTimeAttackCooldown < 0)
        {
            _activeTimeAttackCooldown = timeAttackCooldown;
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.attachedRigidbody.TryGetComponent(out IEssence essence))
        {
            _essences.Add(essence);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody.TryGetComponent(out IEssence essence))
        {
            _essences.Remove(essence);
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        foreach (var essence in _essences)
        {
            essence.GetDamage(damage);
        }
    }
}
