using UnityEngine;
using static PlayerMover;

[RequireComponent(typeof(PlayerAnimator))]
public class KeybordInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerAnimator _animator;

    private void Update()
    {
        MoveState run = MoveState.Run;

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _animator.AnimatorPlay(run);
                _playerMover.MoveRight(run);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _animator.AnimatorPlay(run);
                _playerMover.MoveLeft(run);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.AnimatorPlay(MoveState.Jump);
                _playerMover.Jump();
            }
        }
        else
        {
            _animator.AnimatorPlay(MoveState.Idle);
            _playerMover.Idle();
        }
    }
}
