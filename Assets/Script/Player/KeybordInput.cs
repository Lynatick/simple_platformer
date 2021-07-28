using UnityEngine;
using static Mover;

public class KeybordInput : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;
    [SerializeField] private AnimatorEnemy _animator;

    private void Update()
    {
        if (Input.anyKey)
        {

            if (Input.GetKey(KeyCode.D))
            {
                _animator.AnimatorPlay(MoveState.Walk);
                _playerMover.ChangeOfPosition(MoveState.Walk, DirectionState.Right);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _animator.AnimatorPlay(MoveState.Walk);
                _playerMover.ChangeOfPosition(MoveState.Walk, DirectionState.Left);
            }
            if (Input.GetKey(KeyCode.X))
            {
                _animator.AnimatorPlay(MoveState.Run);
                _playerMover.ChangeOfPosition(MoveState.Run, DirectionState.Right);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                _animator.AnimatorPlay(MoveState.Run);
                _playerMover.ChangeOfPosition(MoveState.Run, DirectionState.Left);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMover.Jump();
                _animator.AnimatorPlay(MoveState.Jump);
            }
        }
        else
        {
            _animator.AnimatorPlay(MoveState.Idle);
            _playerMover.Idle();
        }
    }
}
