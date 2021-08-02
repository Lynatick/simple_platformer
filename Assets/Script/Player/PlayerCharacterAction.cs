using UnityEngine;
using static PlayerMover;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerCharacterAction : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _animator;

    public void Action(Simbols value)
    {
        switch (value)
        {
            case Simbols.D:
                _animator.AnimatorPlay(MoveState.Walk);
                _playerMover.ChangeOfPosition(MoveState.Walk, DirectionState.Right);
                break;
            case Simbols.A:
                _animator.AnimatorPlay(MoveState.Walk);
                _playerMover.ChangeOfPosition(MoveState.Walk, DirectionState.Left);
                break;
            case Simbols.X:
                _animator.AnimatorPlay(MoveState.Run);
                _playerMover.ChangeOfPosition(MoveState.Run, DirectionState.Right);
                break;
            case Simbols.Z:
                _animator.AnimatorPlay(MoveState.Run);
                _playerMover.ChangeOfPosition(MoveState.Run, DirectionState.Left);
                break;
            case Simbols.Space:
                _playerMover.Jump();
                _animator.AnimatorPlay(MoveState.Jump);
                break;
            default:
                _animator.AnimatorPlay(MoveState.Idle);
                _playerMover.Idle();
                break;
        }
    }

    public enum Simbols
    {
        A,
        D,
        Z,
        X,
        Space,
        AnyKey
    }
}