using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 100f;

    public void TakeDamage(float damage)
    {
        _playerHealth -= damage;
        if (_playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}