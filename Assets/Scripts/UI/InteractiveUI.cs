using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InteractiveUI : MonoBehaviour
    {
        
        protected Transform Camera;

        protected void SetCamera()
        {
            Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }

        protected void UpdateUI()
        {
            var newRotation = new Vector3(Camera.position.x, Camera.position.y, Camera.position.z);
            transform.rotation = Quaternion.LookRotation(newRotation, Vector3.forward);
            transform.position = transform.parent.position + new Vector3(0, 1, 0);
        }

        public void Enable(bool state)
        {
            GetComponent<Canvas>().enabled = state;
        }
        
    }
}