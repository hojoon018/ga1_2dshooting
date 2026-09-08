using UnityEngine;

public class Player : MonoBehaviour
{
    // 캡슐화
    // - 데이터 은닉
    // - 메서드를 통한 상태 변경

    [SerializeField] private float _playerHealth = 100f;

    public float PlayerHealth => _playerHealth; // 람다식 문법을 활용한 읽기 전용 프로퍼티

    // 잘 설계된 클래스는
    // - 필드 (인스턴스 변수)
    // - 필드에 잘못된 값이 할당되지 않게 막고, 정상적으로 동작하는 메서드

    // getter/setter : 특정 데이터를 get/set 해주는 메서드

    /*public float GetHealth()
    {
        return _playerHealth;
    }

    public float SetHealth(float value)
    {
        _playerHealth = value;
    }*/

    public void TakeDamage(float damage)
    {
        _playerHealth -= damage;
        if (_playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}