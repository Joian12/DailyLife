using UnityEngine;

public abstract class InputController : MonoBehaviour, ICharacterController
{
    public virtual Vector3 GetDirection() { return default;}
    public virtual void MoveInput(){ }
}