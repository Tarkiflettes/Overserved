using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interactive
{
    public class UIObject : MonoBehaviour
    {
        public float Inclinaison;

        private RectTransform _imageTransform;
        private Image _image;
        private Transform _camera;

        void Start()
        {
            _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
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
            var newRotation = new Vector3(_camera.position.x, _camera.position.y, _camera.position.z);
            var newRotationImage = new Vector3(_camera.position.x, _camera.position.y, _camera.position.z);

            _imageTransform.rotation = Quaternion.LookRotation(newRotationImage, Vector3.forward);
            transform.rotation = Quaternion.LookRotation(newRotation, Vector3.forward);

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