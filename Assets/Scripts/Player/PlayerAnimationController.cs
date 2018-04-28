using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {

        private PlayerController _playerController;
        private PlayerInteraction _playerInteraction;
        private Animator _animator;
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _playerInteraction = GetComponent<PlayerInteraction>();
            _animator = GetComponentInChildren<Animator>();
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            var emission = _particleSystem.emission;
            emission.enabled = _playerController.IsMoving;

            _animator.SetBool("Moving", _playerController.IsMoving);
            _animator.SetBool("HasObject", _playerInteraction.HasObject);
        }

    }
}
