using Assets.Scripts.Interactive.Abstract;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Interactive.Food
{
    public class RottenFood : Usable, ICleanable
    {

        public bool IsClean
        {
            get { return _cleanDuration <= 0; }
        }

        public float SlownessMultiplier = 0.5f;

        private int _cleanDuration = 100;
        // todo : player in to remove slowness on finish cleaning

        public void Clean()
        {
            if (IsClean)
                FinishClean();
            _cleanDuration--;
        }

        public void FinishClean()
        {
            Destroy(gameObject);
        }

        void OnTriggerEnter(Collider col)
        {
            var playerController = col.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
                playerController.Speed *= SlownessMultiplier;
        }

        void OnTriggerExit(Collider col)
        {
            var playerController = col.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
                playerController.Speed /= SlownessMultiplier;
        }

    }
}
