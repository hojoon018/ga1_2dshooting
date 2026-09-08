using UnityEngine;

public class HealthItem : Item
{
    private float _healthRecover = -30f;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.TakeDamage(_healthRecover);
            Debug.Log($"플레이어 체력: {player.PlayerHealth}");
            Destroy(gameObject);
        }
    }
}