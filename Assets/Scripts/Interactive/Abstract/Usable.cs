using UnityEngine;

namespace Assets.Scripts.Interactive.Abstract
{
    public class Usable : Abstract.Interactive
    {

        public override void Interact()
        {
            Debug.Log("Interact Usable : " + name);
        }

        public override void Interact(GameObject obj)
        {
            Debug.Log("Interact Usable : " + name + " with " + obj.name);
        }

        public override bool AcceptRaycast()
        {
            return true;
        }

    }
}
