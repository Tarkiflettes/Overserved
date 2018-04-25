using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Usable : Interactive
    {

        void Start()
        {
            SetUI();
        }

        public override void Interact()
        {
            Debug.Log("Interact Usable : " + name);
        }

        public override void Interact(GameObject obj)
        {
        }

    }
}
