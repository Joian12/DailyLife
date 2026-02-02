using UnityEngine;

public class GridMovement : ICharacterMovement
{
    private float _gridSize = 1f;
    private float _moveSpeed = 5f;

    private Vector3 _targetPosition;
    private Transform _player;

    public GridMovement(Transform player)
    {
        _player = player;
    }

    public void MoveToTarget(Vector3 target)
    {
        _targetPosition = SnapToGrid(target);
    }
    
    private bool IsMoving()
    {
        return Vector3.Distance(_player.position, _targetPosition) > 0.01f;
    }
    
    public void Tick()
    {
        if (IsMoving())
        {
            return;
        }
        
        _player.position = Vector3.MoveTowards(
            _player.position,
            _targetPosition,
            _moveSpeed * Time.deltaTime
        );
    }

    private Vector3 SnapToGrid(Vector3 target)
    {
        target.x = Mathf.Round(target.x / _gridSize) * _gridSize;
        target.z = Mathf.Round(target.z / _gridSize) * _gridSize;
        target.y = _player.position.y;

        return target;
    }
}