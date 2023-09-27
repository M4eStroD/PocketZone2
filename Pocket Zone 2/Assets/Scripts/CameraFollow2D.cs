using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _movingSpeed;
    
    private float _offset = 10;

    private void Awake()
    {
        transform.position = new Vector3()
        {
            x = _playerTransform.position.x,
            y = _playerTransform.position.y,
            z = _playerTransform.position.z - _offset,
        };
    }

    private void Update()
    {
        if (_playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = _playerTransform.position.x,
                y = _playerTransform.position.y,
                z = _playerTransform.position.z - _offset,
            };

            Vector3 pos = Vector3.Lerp(a: transform.position, b: target, t: _movingSpeed * Time.deltaTime);

            transform.position = pos;
        }
    }
}
