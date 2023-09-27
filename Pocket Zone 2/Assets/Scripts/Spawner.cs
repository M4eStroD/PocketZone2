using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Tilemap _plane;
    [SerializeField] private Collider2D[] _colliders;
    [SerializeField] private float _radiusArea = 2f;

    private Vector3 _spawnPos;

    private float x, y;
    private bool _check;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            StartPos();
        }        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) StartPos();
    }

    private void StartPos()
    {
        x = Random.Range(_plane.cellBounds.xMin, _plane.cellBounds.xMax);
        y = Random.Range(_plane.cellBounds.yMin, _plane.cellBounds.yMax);

        _spawnPos = new Vector3(x, y, 3f);

        _check = CheckSpawnPoint(_spawnPos);
        if (_check)
        {
            Instantiate(_enemy, _spawnPos, Quaternion.identity);
        }
        else
            StartPos();
    }

    private bool CheckSpawnPoint(Vector3 spawnPos)
    {
        _colliders = Physics2D.OverlapCircleAll(_spawnPos, _radiusArea);
        if (_colliders.Length != 0)
            return false;
        else 
            return true;
    }

}
