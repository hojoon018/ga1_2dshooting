using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표 : 스페이스바를 누를 떄마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹

    // - 생성 위치(총구)
    public Transform RightFirePoint;
    public Transform LeftFirePoint;

    public bool canFire = true;

    public float coolTime = 0.6f;
    private float _currentCoolTime;
    private float _decreaseCoolTime = 0.01f;

    public float CoolTime => coolTime;

    public bool isAutoFire = false;

    private void Start()
    {
        _currentCoolTime = coolTime;
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        // todo : 직접 생성이 아니라 총알 창고야! 총알 내놔

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isAutoFire = !isAutoFire;
        }

        CheckCoolTime(Time.deltaTime);
        if (canFire)
        {
            if (isAutoFire)
            {
                Bullet autoRightBullet = BulletPool.Instance.GetBullet();
                autoRightBullet.transform.position = RightFirePoint.position; // 생성한 총알의 위치를 나(플레이어)의 위치로

                Bullet autoLeftBullet = BulletPool.Instance.GetBullet();
                autoLeftBullet.transform.position = LeftFirePoint.position;

                canFire = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // 2. 총알 프리팹을 생성한다.
                    // Instantiate는 프리팹으로부터 복사해서 (Monobehaviour를 상속받는) 게임 오브젝트를 생성하고 씬에 넣어주는 기능
                    Bullet rightBullet = BulletPool.Instance.GetBullet();
                    rightBullet.transform.position = RightFirePoint.position; // 생성한 총알의 위치를 나(플레이어)의 위치로

                    Bullet leftBullet = BulletPool.Instance.GetBullet();
                    leftBullet.transform.position = LeftFirePoint.position;

                    canFire = false;
                }
            }
        }
    }

    private void CheckCoolTime(float deltaTime)
    {
        if (canFire == true)
        {
            return;
        }

        _currentCoolTime -= deltaTime;

        if (_currentCoolTime <= 0)
        {
            canFire = true;
            _currentCoolTime = coolTime;
        }
    }

    public void DecreaseCoolTime()
    {
        coolTime -= _decreaseCoolTime;
    }
}