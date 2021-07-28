using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorEnemy : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimatorPlay(Mover.MoveState _moveState)
    {
        _animator.Play(_moveState.ToString());
    }
}
