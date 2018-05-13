using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {

        [Header("Manager")]
        public static GameManager Instance;
        public static AssetsManager AssetsManager;
        public UIManager UIManager;

        [Header("Score")]
        public int PlacedClient;
        public int ServedClient;
        public int MissedReservation;
        public int TakenReservation;

        [Header("Game")]
        public float Duration;

        private float _timeLeft;

        void Awake()
        {
            if (Instance == null)
                Instance = this;

            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            AssetsManager = GetComponent<AssetsManager>();
        }

        private void Start()
        {
            _timeLeft = Duration;
            StartCoroutine(Test());
        }

        private void Update()
        {
            if (_timeLeft <= 0.0f)
                End();
            else
                _timeLeft -= Time.deltaTime;
            UIManager.SetTime((int)Math.Ceiling(_timeLeft));
        }

        private void End()
        {
        }

        private IEnumerator Test()
        {
            yield return new WaitForSeconds(1);
            RingPhone();
        }

        private void RingPhone()
        {
            AssetsManager.Phone.Ring();
        }

    }
}
