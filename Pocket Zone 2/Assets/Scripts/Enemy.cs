using System.Collections;
using UnityEngine;

public class Enemy : Characters
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speedAttack;
    [SerializeField] private float _speedMove;

    [SerializeField] private float _areaCheck;

    [SerializeField] private AssetItem[] _items;
    [SerializeField] private Drop _drop;

    private GameObject _player;
    private Collider2D[] _colliders;

    private Vector2 _curPosition;

    private bool _onTrigger, _isAttack;
    private float currentSpeedAttack = 0;

    private void Start()
    {
        _player = GameObject.Find("Player");
        SetBar();
        currentSpeedAttack = _speedAttack;
    }

    private void Update()
    {
        if (_player.transform.position.x < transform.position.x)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);


        WhoIsWho();

        if (_isAttack)
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speedMove * Time.deltaTime);
    }

    public void WhoIsWho()
    {
        _curPosition.x = transform.position.x;
        _curPosition.y = transform.position.y;
        _colliders = Physics2D.OverlapCircleAll(_curPosition, _areaCheck);

        foreach (Collider2D collider in _colliders)
        {
            if (collider.gameObject.GetComponent<Player>())
            {
                _isAttack = true;
                break;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (_currentHealth <= 0)
        {
            var item = Random.Range(0, _items.Length - 1);
            _drop.Render(_items[item]);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _onTrigger = true;
            StartCoroutine(Attack());
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _onTrigger = false;
            currentSpeedAttack = _speedAttack;
        }
    }

    private IEnumerator Attack()
    {
        while (_onTrigger)
        {
            currentSpeedAttack -= Time.unscaledDeltaTime;

            if (currentSpeedAttack <= 0)
            {
                currentSpeedAttack = _speedAttack;
                _player.GetComponent<Player>().TakeDamage(_damage);
            }

            yield return null;
        }
    }
}
