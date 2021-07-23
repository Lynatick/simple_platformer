using UnityEngine;

public class KeyboardControllerForPlayer : MonoBehaviour
{
    [SerializeField] private Mover _playerMover;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerMover.MoveAndDirection("Walk", "Right");
        }
        if (Input.GetKey(KeyCode.A))
        {
            _playerMover.MoveAndDirection("Walk", "Left");
        }
        if (Input.GetKey(KeyCode.X))
        {
            _playerMover.MoveAndDirection("Run", "Right");
        }
        if (Input.GetKey(KeyCode.Z))
        {
            _playerMover.MoveAndDirection("Run", "Left");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMover.Jump();
        }
    }
}
