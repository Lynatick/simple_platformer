using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimatorPlay(PlayerMover.MoveState _moveState)
    {
        _animator.Play(_moveState.ToString());
    }
}
