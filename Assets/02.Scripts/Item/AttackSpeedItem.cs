using UnityEngine;

public class AttackSpeedItem : Item
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFire player = other.GetComponent<PlayerFire>();

            player.DecreaseCoolTime();
            Destroy(gameObject);
        }
    }
}