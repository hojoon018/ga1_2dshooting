using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _bombTime = 3f;
    private float _bombTimer = 0f;

    private void Update()
    {
        _bombTimer += Time.deltaTime;

        if (_bombTimer >= _bombTime)
        {
            Destroy(gameObject);
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