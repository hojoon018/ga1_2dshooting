using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Transform _bombPosition;

    private float _coolTime = 10f;
    private float _coolTimer = 10f;

    private void Update()
    {
        _coolTimer += Time.deltaTime;
        if (SimpleInput.GetKeyDown(KeyCode.B) && _coolTimer >= _coolTime)
        {
            _coolTimer = 0f;

            Bomb();
        }
    }

    private void Bomb()
    {
        Instantiate(_bombPrefab);
        _bombPrefab.transform.position = _bombPosition.position;
    }
}