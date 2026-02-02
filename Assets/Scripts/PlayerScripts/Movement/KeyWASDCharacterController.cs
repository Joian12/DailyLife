using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class KeyWASDCharacterController : InputController
{
    [SerializeField] private float speed = 5f;

    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public override Vector3 GetDirection()
    {
        return new Vector3(moveInput.x, 0f, moveInput.y);
    }
}