using Unity.VisualScripting;
using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private GameObject _getEffectPrefab;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMove playerMove = other.GetComponent<PlayerMove>();
            Instantiate(_getEffectPrefab, transform.position, Quaternion.identity);

            playerMove.SpeedUp();
            Debug.Log($"플레이어 이동속도 : {playerMove.Speed}");
            Destroy(gameObject);
        }
    }
}