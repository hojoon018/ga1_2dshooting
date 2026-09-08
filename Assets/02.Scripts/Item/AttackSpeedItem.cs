using UnityEngine;

public class AttackSpeedItem : Item
{
    [SerializeField] private GameObject _getEffectPrefab;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerFire player = other.GetComponent<PlayerFire>();
            Instantiate(_getEffectPrefab, transform.position, Quaternion.identity);

            player.DecreaseCoolTime();
            Debug.Log($"플레이어 공격 속도: {player.CoolTime}");
            Destroy(gameObject);
        }
    }
}