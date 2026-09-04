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
            Destroy(gameObject);
        }
    }
}