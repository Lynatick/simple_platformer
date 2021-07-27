using UnityEngine;

public class MoverByPoints : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private Transform _targetNext;
    private Transform _target;
    private int _currentPoint;
    private float _defaultScaleX;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _target = _points[_currentPoint];
        _targetNext = _points[_currentPoint];
        _defaultScaleX = transform.localScale.x;
        Movement();
    }

    private void Update()
    {
        _target = _points[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position.x == _target.position.x)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
                _currentPoint = 0;

            _targetNext = _points[_currentPoint];
            Movement();
        }

    }

    private void Movement()
    {
        if (transform.position.x > _targetNext.position.x)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else
            transform.localScale = new Vector2(_defaultScaleX, transform.localScale.y);
    }
}
