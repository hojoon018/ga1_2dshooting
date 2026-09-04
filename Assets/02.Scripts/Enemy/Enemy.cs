using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] private float _damage;


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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            PlayerStatus player = other.gameObject.GetComponent<PlayerStatus>();

            player.TakeDamage(_damage);
        }
    }
}