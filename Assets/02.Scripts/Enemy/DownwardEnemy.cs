using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class DownWardEnemy : Enemy
{
    protected override void Move()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}