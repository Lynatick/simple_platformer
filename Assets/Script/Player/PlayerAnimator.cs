using UnityEngine;
using static PlayerMover;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private KeybordInput _input;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _input.AnimatorPlay += AnimatorPlay;
    }

    private void OnDisable()
    {
        _input.AnimatorPlay -= AnimatorPlay;
    }

    private void AnimatorPlay(MoveState _moveState)
    {
        _animator.Play(_moveState.ToString());
    }
}
