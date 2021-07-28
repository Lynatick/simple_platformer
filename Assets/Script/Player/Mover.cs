using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Left;
    private int _localeScaleX = 1;
    private Rigidbody2D _rigidbody;
    private float _time = 0;
    private float _cooldown = 0.1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Left : DirectionState.Right;
    }

    public void ChangeOfPosition(MoveState movement, DirectionState direction)
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = movement;
            if (_directionState != direction)
            {
                if (_directionState == DirectionState.Right)
                {
                    _localeScaleX = transform.localScale.x > 0 ? 1 : -1;
                    transform.localScale = new Vector2(-transform.localScale.x * _localeScaleX, transform.localScale.y);
                }

                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                _directionState = direction;
            }
            else
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            _time = _cooldown;
        }
    }

    private void Move(float speed)
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
            Idle();
        else
        {
            _rigidbody.velocity = ((_directionState == DirectionState.Right ? Vector2.right : -Vector2.right) * speed *10 * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _moveState = MoveState.Jump;
        }
    }

    public void Idle()
    {
        _moveState = MoveState.Idle;
    }

    private void Update()
    {
        if (_moveState == MoveState.Jump)
        {
            if (_rigidbody.velocity == Vector2.zero)
                Idle();
        }
        else if (_moveState == MoveState.Walk)
            Move(_walkSpeed);
        else if (_moveState == MoveState.Run)
            Move(_runSpeed);
    }

    public enum MoveState
    {
        Idle,
        Jump,
        Walk,
        Run
    }

    public enum DirectionState
    {
        Right,
        Left
    }
}
