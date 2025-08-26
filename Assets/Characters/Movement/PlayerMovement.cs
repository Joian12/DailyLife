using System;
using UnityEngine;

namespace Characters.Movement {
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Rigidbody2D rb;

        private void Awake() {
            rb.gravityScale = 0;
        }

        void Update() {
            float moveInputX = Input.GetAxisRaw("Horizontal");
            float moveInputY = Input.GetAxisRaw("Vertical");
            
            Vector2 moveInput = new Vector2(moveInputX, moveInputY).normalized;
            
            rb.MovePosition(rb.position + moveInput * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}