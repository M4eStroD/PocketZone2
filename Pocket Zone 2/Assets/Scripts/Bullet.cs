using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;

    private Joystick _jooystick;
    private bool _direction;

    void Start()
    {
        _jooystick = GameObject.Find("Jostick Attack").GetComponent<FixedJoystick>();
        Destroy(gameObject, 2.5f);

        if (_jooystick.Horizontal > 0)
            _direction = true;
        else _direction = false;
    }

    private void Update()
    {
        if (_direction)
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
        Destroy(gameObject);
    }
}
