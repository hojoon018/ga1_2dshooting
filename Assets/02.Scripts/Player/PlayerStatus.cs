using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private bool _isDead = false;

    private void Start()
    {
        _isDead = false;
    }

    private void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        _playerHealth -= damage;
        if (_playerHealth <= 0)
        {
            _isDead = true;
            Destroy(gameObject);
        }
    }
}