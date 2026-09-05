using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] private float _damage;

    [Header("스폰할 아이템 프리팹")][SerializeField]private Item[] _itemPrefabs;

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
            ItemSpawn();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogWarning("플레이어가 null입니다.");
                return;
            }

            player.TakeDamage(_damage);

            Destroy(this.gameObject);
        }
    }

    private void ItemSpawn()
    {
        int randomPercent = Random.Range(0, 100);

        if (randomPercent < 30)
        {
            int itemPrefabIndex = Random.Range(0, 3);;
            Item item = Instantiate(_itemPrefabs[itemPrefabIndex]);
            item.transform.position = transform.position;
        }
    }
    
}