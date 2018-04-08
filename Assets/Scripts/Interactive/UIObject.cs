using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interactive
{
    public class UIObject : MonoBehaviour
    {
        public Transform Camera;
        public float Inclinaison;

        private RectTransform _imageTransform;
        private Image _image;

        void Start()
        {
            Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
            var childs = GetComponentsInChildren<RectTransform>();
            foreach (var child in childs)
            {
                if (child.name != "Icon") continue;
                _imageTransform = child;
                _image = child.GetComponent<Image>();
                break;
            }
        }

        void Update()
        {
            var newRotation = new Vector3(Camera.position.x, Camera.position.y, Camera.position.z);
            var newRotationImage = new Vector3(Camera.position.x, Camera.position.y, Camera.position.z);

            _imageTransform.rotation = Quaternion.LookRotation(newRotationImage, Vector3.up);
            transform.rotation = Quaternion.LookRotation(newRotation, Vector3.up);

            transform.position = transform.parent.position + new Vector3(0, 1, 0);
        }

        public void SetImage(Sprite image)
        {
            _image.sprite = image;
        }

        public void Enable(bool state)
        {
            GetComponent<Canvas>().enabled = state;
        }
    }
}