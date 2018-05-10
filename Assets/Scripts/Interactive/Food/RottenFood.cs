using Assets.Scripts.Interactive.Abstract;
using Assets.Scripts.Player;
using Boo.Lang;
using UnityEngine;

namespace Assets.Scripts.Interactive.Food
{
    public class RottenFood : Usable, ICleanable
    {

        public bool IsClean
        {
            get { return CleanDuration <= 0; }
        }
        public float SlownessMultiplier = 0.5f;
        public int CleanDuration = 100;

        private readonly List<PlayerController> _playersIn;

        public RottenFood()
        {
            _playersIn = new List<PlayerController>();
        }

        public void Clean()
        {
            if (IsClean)
                FinishClean();
            CleanDuration--;
        }

        public void FinishClean()
        {
            for (var i = _playersIn.Count - 1; i >= 0; i--)
            {
                RemovePlayerIn(_playersIn[i]);
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider col)
        {
            AddPlayerIn(col.gameObject.GetComponent<PlayerController>());
        }

        private void OnTriggerExit(Collider col)
        {
            RemovePlayerIn(col.gameObject.GetComponent<PlayerController>());
        }

        private void AddPlayerIn(PlayerController player)
        {
            if (player == null)
                return;
            player.Speed *= SlownessMultiplier;
            _playersIn.Add(player);
        }

        private void RemovePlayerIn(PlayerController player)
        {
            if (player == null)
                return;
            player.Speed /= SlownessMultiplier;
            _playersIn.Remove(player);
        }

    }
}
