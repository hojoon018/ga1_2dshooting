using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    // 목적 : 키보드 입력에 따라서 플레이어 이동 처리를 하고 싶다.

    // 필요 필드:
    [SerializeField] private Animator _animator;
    public float _speed;
    [SerializeField] private TrailRenderer _righttrailRenderer;
    [SerializeField] private TrailRenderer _lefttrailRenderer;

    public float Speed => _speed;

    public float maxPositionY;
    public float minPositionY;

    public float maxPositionX;
    public float minPositionX;

    // 객체가 생성될 때 한 번 실행된다.
    private void Awake()
    {
        // 애니메이터 컴포넌트에 대한 참조를 가져와서 할당한다.
        _animator = GetComponent<Animator>();
    }

    // 매 프레임마다 실행된다.
    // 초당 프레임 실행 횟수는 : 별다른 설정이 없을 경우 가능한 많이
    private void Update()
    {
        Move();
        SpeedChange();
    }

    private void SpeedChange()
    {
        // 6. Q/E 키 눌렀을 때 속도 증가,감소

        if (Input.GetKeyDown(KeyCode.E))
        {
            _speed++;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            _speed--;
        }
    }

    public void SpeedUp()
    {
        _speed++;
    }

    private void Move()
    {
        // 1. 키보드 입력을 받는다.
        float h = Input.GetAxisRaw("Horizontal"); // 키보드 왼/오른쪽 입력 상태에 따라 -1f ~ 0 ~ 1f
        float v = Input.GetAxisRaw("Vertical"); // 키보드 위/아래 입력 상태에 따라 -1f ~ 0 ~ 1f


        // 2. 키보드 입력에 따라 방향을 구한다.
        // 게임에는 벡터라는 타입이 있다. 벡터는(크기와 방향을 의미한다)
        Vector2 normalizedDirection = new Vector2(h, v).normalized; // 왼쪽 방향

        // Vector2 direction = Vector2.left;
        _animator.SetInteger("x", (int)normalizedDirection.x);

        // 3. 방향과 속도에 따라 이동한다.
        Vector2 newPosition = transform.position + (Vector3)normalizedDirection * _speed * Time.deltaTime;

        // 4. 위치 y에 제한이 있다.
        if (newPosition.y > maxPositionY)
        {
            newPosition.y = maxPositionY;
        }
        else if (newPosition.y < minPositionY)
        {
            newPosition.y = minPositionY;
        }


        // 5. 양 옆 끝으로 가면 반대쪽 방향으로 이동
        if (newPosition.x > maxPositionX)
        {
            newPosition.x = minPositionX;
            transform.position = newPosition;
            _righttrailRenderer.transform.localPosition = new Vector3(0.2f, -0.5f, 0f);
            _lefttrailRenderer.transform.localPosition = new Vector3(-0.2f, -0.5f, 0f);
            _righttrailRenderer.Clear();
            _lefttrailRenderer.Clear();
        }
        else if (newPosition.x < minPositionX)
        {
            newPosition.x = maxPositionX;
            transform.position = newPosition;
            _righttrailRenderer.transform.localPosition = new Vector3(0.2f, -0.5f, 0f);
            _lefttrailRenderer.transform.localPosition = new Vector3(-0.2f, -0.5f, 0f);
            _righttrailRenderer.Clear();
            _lefttrailRenderer.Clear();
        }

        transform.position = newPosition;
    }
}