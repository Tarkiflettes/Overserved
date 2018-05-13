using UnityEngine;

namespace Assets.Scripts.UI.Abstract
{
    public abstract class InteractiveUI : MonoBehaviour
    {
        
        protected Transform Camera;

        protected void SetCamera()
        {
            Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }

        protected virtual void UpdateUI()
        {
            var newRotation = new Vector3(Camera.position.x, Camera.position.y, Camera.position.z);
            transform.rotation = Quaternion.LookRotation(newRotation, Vector3.forward);
            transform.position = transform.parent.position + new Vector3(0, 1, 0);
        }

        private void LateUpdate()
        {
            UpdateUI();
        }

        public void Enable(bool state)
        {
            GetComponent<Canvas>().enabled = state;
        }
        
    }
}