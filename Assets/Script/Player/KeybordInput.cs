using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerMover))]
public class KeybordInput : MonoBehaviour
{
    public event UnityAction<Enums.MoveState> AnimatorPlay;
    public event UnityAction<Enums.MoveState, Enums.DirectionState> MoveState;

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveState?.Invoke(Enums.MoveState.Run, Enums.DirectionState.Right);
                AnimatorPlay?.Invoke(Enums.MoveState.Run);
            }
            if (Input.GetKey(KeyCode.A))
            {
                MoveState?.Invoke(Enums.MoveState.Run, Enums.DirectionState.Left);
                AnimatorPlay?.Invoke(Enums.MoveState.Run);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveState?.Invoke(Enums.MoveState.Jump, Enums.DirectionState.Zero);
                AnimatorPlay?.Invoke(Enums.MoveState.Jump);
            }
        }
        else
        {
            MoveState?.Invoke(Enums.MoveState.Idle, Enums.DirectionState.Zero);
            AnimatorPlay?.Invoke(Enums.MoveState.Idle);
        }
    }
}
