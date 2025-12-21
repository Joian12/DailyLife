using UnityEngine;

public interface ICharacterMovement
{
    void MoveToTarget(Vector3 target);
    bool IsMoving();
    void Tick();
}