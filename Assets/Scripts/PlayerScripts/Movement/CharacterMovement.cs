using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private ICharacterMovement _characterMovement;
    private ICharacterController _characterController;

    [SerializeField] private CharacterControllerType _characterControllerType;

    [SerializeField] private TapCharacterController _tapCharacterController;
    [SerializeField] private KeyWASDCharacterController _wasdCharacterController;

    [SerializeField] private float gridSize = 1f;

    [SerializeField] private CharacterController _charController;

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        switch (_characterControllerType)
        {
            case CharacterControllerType.Tap:
                _characterController = _tapCharacterController;
                _characterMovement = new GridMovement(transform);
                break;

            case CharacterControllerType.Keyboard:
                _characterController = _wasdCharacterController;
                _characterMovement = new KeyWASDCharacterMovement(_charController, transform);
                break;
        }
    }

    private void Update()
    {
        _characterMovement.Tick();

        _characterController.MoveInput();

        Vector3 direction = _characterController.GetDirection();

        if (direction == Vector3.zero)
        {
            return;
        }

        Vector3 target = transform.position + new Vector3(
                             Mathf.Round(direction.x),
                             0f,
                             Mathf.Round(direction.z)) * gridSize;

        _characterMovement.MoveToTarget(target);
    }
}