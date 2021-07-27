using UnityEngine;

public class Animator : MonoBehaviour
{
    private UnityEngine.Animator _animator;

    private void Start()
    {
        _animator = GetComponent<UnityEngine.Animator>();
    }

    public void AnimatorPlay(Mover.MoveState _moveState)
    {
        _animator.Play(_moveState.ToString());
    }

    public void AnimatorPlay(string _moveState)
    {
        _animator.Play(_moveState);
    }
}
