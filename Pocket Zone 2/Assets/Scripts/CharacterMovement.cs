using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _offset;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private FixedJoystick _joystickMove;
    [SerializeField] private FixedJoystick _joystickAttack;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _weapon;


    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        float rotateZ = Mathf.Atan2(_joystickAttack.Vertical, _joystickAttack.Horizontal) * Mathf.Rad2Deg;
        _weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);

        _rigidbody.velocity = new Vector2(_joystickMove.Horizontal * _moveSpeed, _joystickMove.Vertical * _moveSpeed);

        Turn(rotateZ);

        if (_joystickMove.Horizontal != 0 || _joystickMove.Vertical != 0)
        {
            Turn();
            _animator.SetBool("isWalk", true);
        }
        else
            _animator.SetBool("isWalk", false); 
    }

    private void Turn()
    {
        Vector2 theScale = transform.localScale;

        if (_joystickAttack.Horizontal > 0)
            theScale.x = 1;
        else if (_joystickAttack.Horizontal < 0)
            theScale.x = -1;
        else
        {
            if (_joystickMove.Horizontal > 0)
                theScale.x = 1;
            else
                theScale.x = -1;
        }

        transform.localScale = theScale;
    }

    private void Turn(float rotateZ)
    {
        Vector3 localScale = Vector3.one;

        if (rotateZ > 90 || rotateZ < -90)
        {
            localScale.x = -1f;
            _offset = 180;
        }
        else
        {
            localScale.x = 1f;
            _offset = 0;
        }

        transform.localScale = localScale;
    }
}
