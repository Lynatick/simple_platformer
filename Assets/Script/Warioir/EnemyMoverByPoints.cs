using UnityEngine;

public class EnemyMoverByPoints : MonoBehaviour
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
        Move();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position.x == _target.position.x)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
                _currentPoint = 0;

            _targetNext = _points[_currentPoint];
            Move();
        }

    }

    private void Move()
    {
        if (transform.position.x > _targetNext.position.x)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else
            transform.localScale = new Vector2(_defaultScaleX, transform.localScale.y);

        _target = _points[_currentPoint];
    }
}
