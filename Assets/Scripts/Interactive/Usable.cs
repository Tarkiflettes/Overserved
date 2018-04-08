using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Usable : Interactive
    {

        void OnGUI()
        {

            base.InitGui();
        }

        void Update()
        {

        }

        public override void Interact()
        {
            Debug.Log("Interact Usable : " + name);
        }
    }
}
