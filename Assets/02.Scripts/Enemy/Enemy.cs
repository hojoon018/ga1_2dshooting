using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] private float _damage;

    [Header("스폰할 아이템 프리팹")][SerializeField] private Item[] _itemPrefabs;

    private Animator _animator;
    private AudioSource _audioSource;

    // Todo : 에너미가 공격 당할 때 재생시켜주는 피격사운드

    // - 죽을 때 생성할 이펙트 프리팹
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health >= 0)
        {
            _audioSource.Play();
        }

        if (_animator != null)
        {
            _animator.SetTrigger("hit");
        }

        if (_health <= 0)
        {
            // 너 죽자
            SpawnDeathEffect();
            SpawnItem();
            Destroy(gameObject);
        }
    }

    private void SpawnDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
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

    private void SpawnItem()
    {
        // Todo : Scriptable Object를 사용해서 리팩토링
        // 이유 1 : 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알 수가 없음
        // 이유 2: 각 아이템 스폰 확률을 매직 넘버로 하드코딩해서 유지보수가 어렵
        int randomPercent = Random.Range(0, 100);

        if (randomPercent < 30)
        {
            int itemPrefabIndex = Random.Range(0, 2);
            Item item = Instantiate(_itemPrefabs[itemPrefabIndex]);
            item.transform.position = transform.position;
        }
    }
}