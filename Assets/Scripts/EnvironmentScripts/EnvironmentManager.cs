using System.Collections.Generic;
using UnityEngine;

namespace EnvironmentScripts {
    public class EnvironmentManager : MonoBehaviour {
        public static EnvironmentManager Current;

        //get next scene and get what door. 

        [SerializeField] private List<Environment> _environments = new();
        [SerializeField] private int _previousEnvironment;
        
        private void Awake() {
            Current = this;
        }
        
        public void ActivateNextEnvironment(Path path) {
            Environment environment = _environments.Find(x => x.GetID() == path.GetNextEnvironmentID());
            environment.gameObject.SetActive(true);
            _previousEnvironment = path.GetCurrentEnvironmentID();
        }

        public void DeactivatePreviousEnvironment() {
            var environment = _environments.Find(x => x.GetID() == _previousEnvironment);
            if (environment != null) {
                environment.gameObject.SetActive(false);
            }
        }
    }
}


