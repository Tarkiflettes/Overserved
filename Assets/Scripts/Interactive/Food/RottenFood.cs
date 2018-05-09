using Assets.Scripts.Interactive.Abstract;
using UnityEngine;

namespace Assets.Scripts.Interactive.Food
{
    public class RottenFood : Usable, ICleanable
    {
        
        public override void Interact(GameObject obj)
        {
            var broom = obj.GetComponent<Broom>();
        }

        public void Clean()
        {
        }

        public void FinishClean()
        {
        }

    }
}
