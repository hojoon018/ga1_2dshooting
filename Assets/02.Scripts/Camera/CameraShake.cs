using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeAmount = 0.05f;
    private float _shakeTime;
    Vector3 _shakePosition;

    public void VibrateForTime(float time)
    {
        _shakeTime = time;
    }

    private void Start()
    {
        _shakePosition = new Vector3(0f, 0f, -10f);
    }

    private void Update()
    {
        if (_shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * _shakeAmount + _shakePosition;
            _shakeTime -= Time.deltaTime;
        }
        else
        {
            _shakeTime = 0f;
            transform.position = _shakePosition;
        }
    }
}