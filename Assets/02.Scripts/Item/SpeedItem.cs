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
            Debug.Log($"플레이어 이동속도 : {playerMove.Speed}");
            Destroy(gameObject);
        }
    }
}