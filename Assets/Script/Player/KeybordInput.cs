using UnityEngine;
using static PlayerCharacterAction;

[RequireComponent(typeof(PlayerCharacterAction))]
public class KeybordInput : MonoBehaviour
{
    [SerializeField] private PlayerCharacterAction _action;

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.D))
                _action.Action(Simbols.D);
            if (Input.GetKey(KeyCode.A))
                _action.Action(Simbols.A);
            if (Input.GetKey(KeyCode.X))
                _action.Action(Simbols.X);
            if (Input.GetKey(KeyCode.Z))
                _action.Action(Simbols.Z);
            if (Input.GetKeyDown(KeyCode.Space))
                _action.Action(Simbols.Space);
        }
        else
        {
            _action.Action(Simbols.AnyKey);
        }
    }
}
