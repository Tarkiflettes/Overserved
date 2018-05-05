using Assets.Scripts.Interactive.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactive
{
    public class Trash : Usable
    {

        public override void Interact()
        {
        }

        public override void Interact(GameObject obj)
        {
            Destroy(obj);
        }

    }
}
