using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _effect;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private TMP_Text _textCountAmmo;

    [SerializeField] private Animator _outputAK;

    [SerializeField] private float _startTimeBetweenShots;

    private float _timeBetweenShots;

    public int _countAmmo;

    private void Update()
    {
        if (_countAmmo > 0)
        {
            if (_timeBetweenShots <= 0)
            {
                if (_joystick.Vertical != 0 || _joystick.Horizontal != 0)
                {
                    _countAmmo--;
                    _textCountAmmo.text = _countAmmo.ToString();
                    _outputAK.SetBool("isOutput", true);
                    Instantiate(_effect, _shotPoint.transform);
                    Instantiate(_bullet, _shotPoint.position, transform.rotation);
                    _timeBetweenShots = _startTimeBetweenShots;
                }
                _outputAK.SetBool("isOutput", false);
            }
            else
            {
                _timeBetweenShots -= Time.deltaTime;
            }
        }
    }
}
