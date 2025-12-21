using UnityEngine;

public abstract class InputController : MonoBehaviour, ICharacterController
{
    public abstract Vector3 GetDirection();
    public abstract void MoveInput();
}