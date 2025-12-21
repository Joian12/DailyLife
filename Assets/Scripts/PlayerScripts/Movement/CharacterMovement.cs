using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private ICharacterMovement _characterMovement;
    private ICharacterController _characterController;
    
    private CharacterControllerType _characterControllerType;
    
    [SerializeField] private TapCharacterController _tapCharacterController;
    
    private void Awake()
    {
        Setup();
    }
    
    private void Setup()
    {
        _characterMovement = new GridMovement(this.transform);
        
        switch (_characterControllerType)
        {
            case CharacterControllerType.Tap:
                _characterController = _tapCharacterController;
                break;
            case CharacterControllerType.JoyStick: //no joystick yet
            case CharacterControllerType.Keyboard: //no keyboard yet
            default:
                break;
        }
    } 

    private void Update()
    {
        _characterMovement.Tick();
        
        if (_characterMovement.IsMoving())
        {
            return;
        } 
        
        _characterController.MoveInput();
        
        Vector3 target = _characterController.GetDirection();
        
        _characterMovement.MoveToTarget(target);
    }
}

public enum CharacterControllerType
{
    Tap,
    JoyStick,
    Keyboard,
}