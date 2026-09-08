using UnityEngine;

public class AimedEnemy : Enemy
{
    private GameObject _player;
    private Vector2 _direction;


    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.Log("플레이어 태그를 가진 게임 오브젝트를 찾지 못했습니다.");
            return;
        }

        _direction = _player.transform.position - transform.position;
        _direction.Normalize();
        float radian = Mathf.Atan2(_direction.y, _direction.x);
        float degree = radian * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, degree + 90f);
    }
    protected override void Move()
    {
        if (_player == null)
        {
            return;
        }

        // 방향과 속도에 맞게 이동한다.
        transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
    }
}