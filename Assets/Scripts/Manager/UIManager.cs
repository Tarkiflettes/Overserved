using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Manager
{
    public class UIManager : MonoBehaviour
    {

        public GameObject EventsPanel;
        public Text Time;
        public Text Score;

        private List<EventUI> _events;

        private void Start()
        {
            _events = new List<EventUI>();
            //StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            yield return new WaitForSeconds(1);
            AddEvent(null);
            yield return new WaitForSeconds(2);
            AddEvent(null);
            yield return new WaitForSeconds(1);
            AddEvent(null);
            yield return new WaitForSeconds(1);
            RemoveEvent(_events[0]);
            yield return new WaitForSeconds(2);
            RemoveEvent(_events[1]);
            yield return new WaitForSeconds(2);
            AddEvent(null);
            AddEvent(null);
            yield return new WaitForSeconds(1);
        }

        public EventUI AddEvent(Sprite image)
        {
            var ui = Instantiate(GameManager.AssetsManager.EventUI);
            var eUI = ui.GetComponentInChildren<EventUI>();
            if (eUI == null)
                return null;
            eUI.transform.SetParent(EventsPanel.transform, false);
            eUI.Init(image);
            _events.Add(eUI);
            ResetEventsPosition();
            return eUI;
        }

        public void RemoveEvent(EventUI eventUI)
        {
            _events.Remove(eventUI);
            Destroy(eventUI.gameObject);
            ResetEventsPosition();
        }

        private void ResetEventsPosition()
        {
            if (_events.Count <= 0)
                return;
            var firstRectTransform = _events[0].GetComponent<RectTransform>();
            if (firstRectTransform == null)
                return;
            var currentX = firstRectTransform.rect.width / 2;
            foreach (var e in _events)
            {
                var rectTransform = e.GetComponent<RectTransform>();
                var pos = rectTransform.position;
                pos.x = currentX;
                e.GetComponent<RectTransform>().position = pos;
                currentX += rectTransform.rect.width;
            }
        }

        public void SetScore(int score)
        {
            Score.text = score.ToString();
        }

        public void SetTime(int timeLeft)
        {
            var timeSpan = new TimeSpan(0, 0, timeLeft);
            var time = string.Format("{0:00}:{1:00}",
                (int)timeSpan.TotalMinutes,
                timeSpan.Seconds);
            Time.text = time;
        }

    }
}
