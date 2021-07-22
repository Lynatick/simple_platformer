using UnityEngine;

[RequireComponent(typeof(Player))]
public class KeyboardController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _player.Right("Walk");
        }
        if (Input.GetKey(KeyCode.A))
        {
            _player.Left("Walk");
        }
        if (Input.GetKey(KeyCode.X))
        {
            _player.Right("Run");
        }
        if (Input.GetKey(KeyCode.Z))
        {
            _player.Left("Run");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Jump();
        }
    }
}
