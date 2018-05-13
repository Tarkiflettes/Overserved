using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        private const float RotationSpeed = 20f;

        public float Speed;
        public float DashSpeed;
        public int DashTime;

        public float AnimationTolerance = 0.1f;

        public bool IsMoving = false;
        public int PlayerNumber;

        public Joystick Joystick { get; private set; }

        private CharacterController _characterController;
        private int _currentDashTime;
        private float _defaultPositionY;

        private void Start()
        {
            Joystick = new Joystick(PlayerNumber);
            _characterController = GetComponent<CharacterController>();
            _currentDashTime = DashTime;
            _defaultPositionY = transform.position.y + _characterController.skinWidth;
        }

        private void FixedUpdate()
        {
            var axisHorizontal = Input.GetAxisRaw(Joystick.Horizontal);
            var axisVertical = Input.GetAxisRaw(Joystick.Vertical);
            var moveDirection = new Vector3(axisHorizontal, 0, axisVertical);
            var speed = Speed;

            IsMoving = Math.Abs(axisVertical) > AnimationTolerance || Math.Abs(axisHorizontal) > AnimationTolerance;

            if (!_characterController.isGrounded)
                transform.position = new Vector3(
                    transform.position.x,
                    _defaultPositionY,
                    transform.position.z);

            if (moveDirection.sqrMagnitude > 0.05f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * RotationSpeed);

            if (Input.GetButtonDown(Joystick.Dash) && _currentDashTime == DashTime)
            {
                _currentDashTime = 0;
            }

            if (_currentDashTime < DashTime)
            {
                speed = DashSpeed;
                _currentDashTime++;
            }

            _characterController.Move(moveDirection.normalized * Time.deltaTime * speed);
        }

    }
}
