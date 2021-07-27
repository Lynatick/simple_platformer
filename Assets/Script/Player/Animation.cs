using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Animat(string stateName)
    {
        _animator.Play(stateName);
    }
}
