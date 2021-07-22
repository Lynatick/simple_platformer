using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private string _moveState = "Idle";
    private string _directionState = "Left";
    private int _localeScaleX = 1;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animatorController;
    private float _time = 0;
    private float _cooldown = 0.1f;
    private int _coin;

    public event UnityAction<int> CoinChanged;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
        _directionState = transform.localScale.x > 0 ? "Left" : "Right";
    }

    public void Right(string movement)
    {
        if (_moveState != "Jump")
        {
            _moveState = movement;
            if (_directionState == "Left")
            {
                _transform.localScale = new Vector2(-_transform.localScale.x, _transform.localScale.y);
                _directionState = "Right";
            }
            else
                _transform.localScale = new Vector2(_transform.localScale.x, _transform.localScale.y);
            _time = _cooldown;
            _animatorController.Play(_moveState);
        }
    }

    public void Left(string movement)
    {
        if (_moveState != "Jump")
        {
            _moveState = movement;
            if (_directionState == "Right")
            {
                _localeScaleX = transform.localScale.x > 0 ? 1 : -1;
                _transform.localScale = new Vector2(_transform.localScale.x * _localeScaleX, _transform.localScale.y);
                _directionState = "Left";
            }
            else
                _transform.localScale = new Vector2(_transform.localScale.x, _transform.localScale.y);
            _time = _cooldown;
            _animatorController.Play(_moveState);
        }
    }

    public void Jump()
    {
        if (_moveState != "Jump")
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _moveState = "Jump";
            _animatorController.Play(_moveState);
        }
    }

    private void Idle()
    {
        _moveState = "Idle";
        _animatorController.Play(_moveState);
    }

    private void Update()
    {
        if (_moveState == "Jump")
        {
            if (_rigidbody.velocity == Vector2.zero)
                Idle();
        }
        else if (_moveState == "Walk")
            Move(_walkSpeed);
        else if (_moveState == "Run")
            Move(_runSpeed);
    }

    public void IncreaseCoins()
    {
        _coin++;
        CoinChanged?.Invoke(_coin);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            IncreaseCoins();
            Destroy(collision.gameObject);
        }
    }
}
