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
        if (Input.GetKeyDown(KeyCode.B) && _coolTimer >= _coolTime)
        {
            _coolTimer = 0f;

            Instantiate(_bombPrefab);
            _bombPrefab.transform.position = _bombPosition.position;
        }
    }
}