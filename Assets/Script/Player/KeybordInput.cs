using UnityEngine;
using UnityEngine.Events;
using static PlayerMover;

[RequireComponent(typeof(PlayerAnimator))]
public class KeybordInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _animator;

    private MoveState _moveState;
    private DirectionState _directionState = DirectionState.Left;

    public event UnityAction<MoveState> AnimatorPlay;
    public event UnityAction<MoveState, DirectionState> MoveState;

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _moveState = PlayerMover.MoveState.Run;
                _directionState = DirectionState.Right;
                MoveState?.Invoke(_moveState, _directionState);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _moveState = PlayerMover.MoveState.Run;
                _directionState = DirectionState.Left;
                MoveState?.Invoke(_moveState, _directionState);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _moveState = PlayerMover.MoveState.Jump;
                MoveState?.Invoke(_moveState, _directionState);
            }
        }
        else
        {
            _moveState = PlayerMover.MoveState.Idle;
            MoveState?.Invoke(_moveState, _directionState);
        }
        AnimatorPlay?.Invoke(_moveState);
    }
}
