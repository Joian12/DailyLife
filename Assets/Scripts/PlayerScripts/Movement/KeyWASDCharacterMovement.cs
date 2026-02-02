using UnityEngine;

public sealed class KeyWASDCharacterMovement : ICharacterMovement
{
    private Vector3 _target;
    private readonly Transform _player;
    private readonly CharacterController _characterController;

    private const float Speed = 5f;

    public KeyWASDCharacterMovement(CharacterController characterController, Transform player)
    {
        _characterController = characterController;
        _player = player;

        _target = player.position;
    }

    public void MoveToTarget(Vector3 target)
    {
        _target = target;
    }

    private bool HasDistance()
    {
        return Vector3.Distance(_player.position, _target) > 0.01f;
    }

    public void Tick()
    {
        if (HasDistance() == false)
        {
            return;
        }
        
        Vector3 direction = (_target - _player.position);
        direction.y = 0f;

        if (direction.sqrMagnitude < 0.0001f)
            return;

        Vector3 move =
            direction.normalized * Speed * Time.deltaTime;

        _characterController.Move(move);
    }
}