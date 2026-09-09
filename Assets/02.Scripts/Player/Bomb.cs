using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _bombTime = 3f;
    private float _bombTimer = 0f;
    CameraShake _cameraShake;

    [SerializeField] private GameObject _bombEndEffect;

    private void Start()
    {
        _cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        _cameraShake.VibrateForTime(_bombTime);
    }

    private void Update()
    {
        _bombTimer += Time.deltaTime;

        if (_bombTimer >= _bombTime)
        {
            Destroy(gameObject);
            Instantiate(_bombEndEffect, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            enemy.TakeDamage(float.MaxValue);
        }
    }
}