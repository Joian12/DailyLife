using UnityEngine;

public interface ICharacterController
{
    Vector3 GetDirection();
    void MoveInput();
}