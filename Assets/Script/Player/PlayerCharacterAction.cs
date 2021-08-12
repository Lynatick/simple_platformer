using UnityEngine;
using static PlayerMover;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerCharacterAction : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _animator;

    public void Action(Simbols value)
    {
        MoveState run = MoveState.Run;

        switch (value)
        {
            case Simbols.D:
                _animator.AnimatorPlay(run);
                _playerMover.MoveRight(run);
                break;
            case Simbols.A:
                _animator.AnimatorPlay(run);
                _playerMover.MoveLeft(run);
                break;
            case Simbols.Space:
                _animator.AnimatorPlay(MoveState.Jump);
                _playerMover.Jump();
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
        Space,
        AnyKey
    }
}