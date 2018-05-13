using Assets.Scripts.UI.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class Icon : InteractiveUI
    {

        public Image IconImage;

        private void Start()
        {
            SetCamera();
        }
        
        protected override void UpdateUI()
        {
            base.UpdateUI();

            var newRotationImage = new Vector3(Camera.position.x, Camera.position.y, Camera.position.z);
            IconImage.transform.rotation = Quaternion.LookRotation(newRotationImage, Vector3.forward);
        }

        public void SetImage(Sprite image)
        {
            IconImage.sprite = image;
        }

    }
}
