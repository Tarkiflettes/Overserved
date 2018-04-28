using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Trash : Usable
    {

        private void Start()
        {
            SetUI();
        }

        public override void Interact()
        {
        }

        public override void Interact(GameObject obj)
        {
            Destroy(obj);
        }

    }
}
