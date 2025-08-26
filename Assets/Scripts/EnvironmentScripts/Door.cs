using System;
using UnityEngine;

namespace EnvironmentScripts {
    public class Door : MonoBehaviour,  IInteractable {
        [SerializeField] private Path _path; // should be scriptable
        
        public void ShowBubble() {
            // show bubble ask
        }

        public void HideBubble() {
            // show bubble ask
        }

        public void Interact() {
            Debug.Log("interacting to Door: "+_path.CurrentDoor()+" in Environment: "+_path.GetCurrentEnvironmentID());
            EnvironmentManager.Current.ActivateNextEnvironment(_path);
            EnvironmentManager.Current.DeactivatePreviousEnvironment();
        }

        public Path GetPath() {
            return _path;
        }
    }
    
    [Serializable]
    public class Path : IPath {
        [SerializeField] private int _currentEnvironment;
        [SerializeField] private int _nextEnvironment;
        [SerializeField] private int _currentDoor;
        [SerializeField] private int _nextDoor;
        
        public int CurrentDoor() {
            return _currentDoor;
        }

        public int NextDoor() {
            return _nextDoor;
        }

        public int GetCurrentEnvironmentID() {
            return _currentEnvironment;
        }
        
        public int GetNextEnvironmentID() {
            return _nextEnvironment;
        }
    }
    
    public interface IPath {
        int CurrentDoor();
        int NextDoor();
    }
}