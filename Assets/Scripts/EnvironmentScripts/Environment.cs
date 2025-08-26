using System;
using UnityEngine;

namespace EnvironmentScripts {
    [Serializable]
    public class Environment : MonoBehaviour {

        [SerializeField] private int _environmentID;
        
        [SerializeField] private Door[] _doors; //environment pathway

        private void OnEnable() {
            
        }

        private void OnDisable() {
            
        }

        public int GetID() {
            return _environmentID;
        }
    }
}