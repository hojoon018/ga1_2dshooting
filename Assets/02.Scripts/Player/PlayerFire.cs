using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표 : 스페이스바를 누를 떄마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    public GameObject LittleBulletPrefab;
    // - 생성 위치(총구)
    public Transform RightFirePoint;
    public Transform LeftFirePoint;
    
    public Transform LittleRightFirePoint;
    public Transform LittleLeftFirePoint;

    public bool canFire = true;
    public float coolTime = 1f;

    public bool isAutoFire = false;

    private float currentCoolTime = 1f;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isAutoFire = !isAutoFire;
        }
        CheckCoolTime(Time.deltaTime);
        if (canFire)
        {
            if (isAutoFire)
            {
                GameObject autoRightBullet = Instantiate(BulletPrefab);
                autoRightBullet.transform.position = RightFirePoint.position; // 생성한 총알의 위치를 나(플레이어)의 위치로
            
                GameObject autoLeftBullet = Instantiate(BulletPrefab);
                autoLeftBullet.transform.position = LeftFirePoint.position;
                
                GameObject autoLittleRightBullet = Instantiate(LittleBulletPrefab);
                autoLittleRightBullet.transform.position = LittleRightFirePoint.position;
                
                GameObject autoLittleLeftBullet = Instantiate(LittleBulletPrefab);
                autoLittleLeftBullet.transform.position = LittleLeftFirePoint.position;
                
                canFire = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // 2. 총알 프리팹을 생성한다.
                    // Instantiate는 프리팹으로부터 복사해서 (Monobehaviour를 상속받는) 게임 오브젝트를 생성하고 씬에 넣어주는 기능
                    GameObject rightBullet = Instantiate(BulletPrefab);
                    rightBullet.transform.position = RightFirePoint.position; // 생성한 총알의 위치를 나(플레이어)의 위치로
            
                    GameObject leftBullet = Instantiate(BulletPrefab);
                    leftBullet.transform.position = LeftFirePoint.position;
                    
                    GameObject littleRightBullet = Instantiate(LittleBulletPrefab);
                    littleRightBullet.transform.position = LittleRightFirePoint.position;
                    
                    GameObject littleLeftBullet = Instantiate(LittleBulletPrefab);
                    littleLeftBullet.transform.position = LittleLeftFirePoint.position;
                    
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
        
        currentCoolTime -= deltaTime;
        
        if (currentCoolTime <= 0)
        {
            canFire = true;
            currentCoolTime = coolTime;
        }
    }
}
