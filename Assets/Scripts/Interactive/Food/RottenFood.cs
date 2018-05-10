using System;
using Assets.Scripts.Interactive.Abstract;
using Assets.Scripts.Player;
using Boo.Lang;
using UnityEngine;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Interactive.Food
{
    public class RottenFood : Usable, ICleanable
    {

        public bool IsClean
        {
            get { return _cleanDuration <= 0; }
        }
        public readonly float SlownessMultiplier = 0.5f;
        public readonly int CleanDuration = 100;

        private int _cleanDuration;

        private List<PlayerController> _playersIn;

        protected override void Init()
        {
            base.Init();
            _playersIn = new List<PlayerController>();
            _cleanDuration = CleanDuration;
            EnableProgressbar(true);
            ProgressBar.SetValue(_cleanDuration.ToPercent(CleanDuration));
        }

        public void Clean()
        {
            if (IsClean)
                FinishClean();
            _cleanDuration--;
            ProgressBar.SetValue(_cleanDuration.ToPercent(CleanDuration));
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
