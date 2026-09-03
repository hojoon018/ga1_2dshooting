using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed;


    public void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            // 너 죽자
            Destroy(gameObject);
        }
    }
}