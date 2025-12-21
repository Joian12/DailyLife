using UnityEngine;
using UnityEngine.Serialization;

public class TapCharacterController : InputController
{
    private Vector3 _direction;
    private Camera Camera => Camera.main;
    public LayerMask _groundLayer;
    
    public override Vector3 GetDirection()
    {
        return _direction;
    }   

    public override void MoveInput()
    {
        if (Input.GetMouseButtonDown(0)) // tap or click
        {
            TapGround();
        }
    }

    private void TapGround()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, _groundLayer))
        {
            _direction = hit.point;
            
            Debug.Log("Tapped ground at: " + hit.point);
            Debug.DrawRay(_direction, Vector3.up, Color.red);
        }
    }
}