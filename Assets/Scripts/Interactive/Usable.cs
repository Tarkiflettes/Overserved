using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Usable : Interactive
    {

        public override void Interact()
        {
            Debug.Log("Interact Usable : " + name);
        }

        public override void Interact(GameObject obj)
        {
            Debug.Log("Interact Usable : " + name + " with " + obj.name);
        }

    }
}
