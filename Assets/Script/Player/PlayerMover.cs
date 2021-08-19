using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private KeybordInput _input;

    private Enums.MoveState _moveState = Enums.MoveState.Idle;
    private Enums.DirectionState _directionState = Enums.DirectionState.Left;
    private int _localeScaleX = 1;
    private Rigidbody2D _rigidbody;
    private float _time = 0;
    private readonly float _cooldown = 0.1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _directionState = transform.localScale.x > 0 ? Enums.DirectionState.Left : Enums.DirectionState.Right;
    }

    private void OnEnable()
    {
        _input.MoveState += Move;
    }

    private void OnDisable()
    {
        _input.MoveState -= Move;
    }

    private void Move(Enums.MoveState _moveState, Enums.DirectionState _directionState)
    {
        switch (_moveState)
        {
            case Enums.MoveState.Run:
                ChangeOfPosition(_moveState, _directionState);
                break;
            case Enums.MoveState.Idle:
                Idle();
                break;
            case Enums.MoveState.Jump:
                Jump();
                break;
        }
    }

    private void ChangeOfPosition(Enums.MoveState movement, Enums.DirectionState direction)
    {
        if (_moveState != Enums.MoveState.Jump)
        {
            _moveState = movement;

            if (_directionState != direction)
            {
                if (_directionState == Enums.DirectionState.Right)
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

    private void Update()
    {
        if (_moveState == Enums.MoveState.Jump)
        {
            if (_rigidbody.velocity == Vector2.zero)
                Idle();
        }
        else if (_moveState == Enums.MoveState.Run)
            Run();
    }

    private void Run()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
            Idle();
        else
        {
            _rigidbody.velocity = ((_directionState == Enums.DirectionState.Right ? Vector2.right : -Vector2.right) *
                _runSpeed);
        }
    }

    private void Jump()
    {
        if (_moveState != Enums.MoveState.Jump)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _moveState = Enums.MoveState.Jump;
        }
    }

    private void Idle()
    {
        _moveState = Enums.MoveState.Idle;
    }
}
