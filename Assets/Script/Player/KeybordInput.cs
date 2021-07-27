using UnityEngine;

public class KeybordInput : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerMover.ChangeOfPosition(Mover.MoveState.Walk, Mover.DirectionState.Right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _playerMover.ChangeOfPosition(Mover.MoveState.Walk, Mover.DirectionState.Left);
        }
        if (Input.GetKey(KeyCode.X))
        {
            _playerMover.ChangeOfPosition(Mover.MoveState.Run, Mover.DirectionState.Right);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            _playerMover.ChangeOfPosition(Mover.MoveState.Run, Mover.DirectionState.Left);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMover.Jump();
        }
    }
}
