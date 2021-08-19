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
        _input.AnimatorPlay += Play;
    }

    private void OnDisable()
    {
        _input.AnimatorPlay -= Play;
    }

    private void Play(Enums.MoveState _moveState)
    {
        _animator.Play(_moveState.ToString());
    }
}
