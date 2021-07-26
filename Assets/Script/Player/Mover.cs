using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private MoveState _moveState = MoveState.Idle;
    private string _directionState;
    private int _localeScaleX = 1;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _time = 0;
    private float _cooldown = 0.1f;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _directionState = transform.localScale.x > 0 ? "Left" : "Right";
    }

    public void Movement(MoveState movement, string direction)
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = movement;
            if (_directionState != direction)
            {
                if (_directionState == "Right")
                {
                    _localeScaleX = transform.localScale.x > 0 ? 1 : -1;
                    _transform.localScale = new Vector2(-_transform.localScale.x * _localeScaleX, _transform.localScale.y);
                }

                _transform.localScale = new Vector2(-_transform.localScale.x, _transform.localScale.y);
                _directionState = direction;
            }
            else
                _transform.localScale = new Vector2(_transform.localScale.x, _transform.localScale.y);
            _time = _cooldown;
            _animator.Play(_moveState.ToString());
        }
    }

    private void Move(float speed)
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
            Idle();
        else
        {
            if (_directionState == "Right")
                _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
            else
                _rigidbody.velocity = new Vector2(-speed, _rigidbody.velocity.y);
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _moveState = MoveState.Jump;
            _animator.Play(_moveState.ToString());
        }
    }

    private void Idle()
    {
        _moveState = MoveState.Idle;
        _animator.Play(_moveState.ToString());
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
}
