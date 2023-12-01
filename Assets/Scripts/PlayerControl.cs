using System;
using UnityEngine;
using UnityEngine.UI;

public interface IEssence
{
    public void GetDamage(int damage);
}

public class PlayerControl : MonoBehaviour, IEssence
{
    public int speed;
    public bool isTurnRight = true;
    public Animator effectsAnimator;
    public float timeAttackCooldown = 0.9f;
    public LayerMask enemyLayer;
    public int damage;
    public int health = 100;
    public Slider healthBar;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _activeTimeAttackCooldown;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void Flip()
    {
        isTurnRight = !isTurnRight;
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }

    private void Update()
    {
        _activeTimeAttackCooldown -= Time.deltaTime;
        Vector3 nextVector3 = Vector3.zero;
        if (Input.GetKey("w"))
        {
            nextVector3 += Vector3.up * speed * Time.deltaTime;
        } 
        else if (Input.GetKey("s"))
        {
            nextVector3 += Vector3.down * speed * Time.deltaTime;
        }
        
        if (Input.GetKey("a"))
        {
            if(isTurnRight) Flip();
            nextVector3 += -Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey("d"))
        {
            if(!isTurnRight) Flip();
            nextVector3 += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && _activeTimeAttackCooldown < 0)
        {
            _activeTimeAttackCooldown = timeAttackCooldown;
            Attack();
        }

        _animator.SetBool("isIdle", nextVector3 == Vector3.zero);

        _rigidbody2D.MovePosition(transform.position + nextVector3 * speed);
    }

    public void GetDamage(int damage)
    {
        _spriteRenderer.color = Color.red;
        Invoke(nameof(SetPlayerWhiteColor), 0.5f);
        healthBar.value -= damage;
        health -= damage;
    }

    public void SetPlayerWhiteColor()
    {
        _spriteRenderer.color = Color.white;
    }

    public void Attack()
    {
        effectsAnimator.SetTrigger("Attack");
        var colliders = Physics2D.OverlapBoxAll(effectsAnimator.transform.position, 
            Vector2.one, 0f,enemyLayer);
        foreach (var raycastHit2D in colliders)
        {
            raycastHit2D.attachedRigidbody.GetComponent<IEssence>().GetDamage(damage);
        }
    }
}
