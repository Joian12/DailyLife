using UnityEngine;

public interface ICharacterMovement
{
    void MoveToTarget(Vector3 target);
    void Tick();
}