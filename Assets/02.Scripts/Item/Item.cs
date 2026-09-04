using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private float _moveInterval = 4f;
    private float _timer;

    private GameObject _player;

    [SerializeField] private float _speed;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _moveInterval)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();

        transform.Translate(direction * _speed * Time.deltaTime);
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);
}