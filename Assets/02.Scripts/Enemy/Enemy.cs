using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100;
    public float speed;

    private void Update()
    {
        Vector2 direction = Vector2.down; // new Vector2(1, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}