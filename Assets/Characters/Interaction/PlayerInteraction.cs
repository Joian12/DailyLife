using System;
using EnvironmentScripts;
using UnityEngine;

namespace Characters.Interaction {
    public class PlayerInteraction : MonoBehaviour {
        private IInteractable _currentInteractable;
        
        private void Update() {
            if (Input.GetKeyDown(KeyCode.X)) {
                _currentInteractable?.Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();

            if (interactable != null) {
                _currentInteractable = interactable;
                interactable.ShowBubble();
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();

            if (interactable != null) {
                interactable.HideBubble();
            }
        }
    }
}