using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float timeAttackCooldown = 0.9f;
    private float _activeTimeAttackCooldown;
    private Animator _animator; 

    void Start()
    {
        _animator = GetComponent<Animator>();
        _activeTimeAttackCooldown = timeAttackCooldown;
    }

    void Update()
    {
        _activeTimeAttackCooldown -= Time.deltaTime;
        if (_activeTimeAttackCooldown < 0)
        {
            _activeTimeAttackCooldown = timeAttackCooldown;
            Attack();
        }
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
        Debug.Log("Player attacked by trap");
    }
}
