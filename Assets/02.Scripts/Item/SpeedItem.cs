using Unity.VisualScripting;
using UnityEngine;

public class SpeedItem : Item
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>();

            playerMove.SpeedUp();
        }
    }
}