using UnityEngine;

public class KeybordInput : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerMover.Movement(Mover.MoveState.Walk, "Right");
        }
        if (Input.GetKey(KeyCode.A))
        {
            _playerMover.Movement(Mover.MoveState.Walk, "Left");
        }
        if (Input.GetKey(KeyCode.X))
        {
            _playerMover.Movement(Mover.MoveState.Run, "Right");
        }
        if (Input.GetKey(KeyCode.Z))
        {
            _playerMover.Movement(Mover.MoveState.Run, "Left");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMover.Jump();
        }
    }
}
