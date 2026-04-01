using System.Collections;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(PlayerAnimator), typeof(PlayerInput))]
public class Player : MonoBehaviour {
    [Header("Movement")] [SerializeField] private float moveSpeed = 8;
    [SerializeField] [Range(0, 1)] private float accelAirborned = .75f;

    [Header("Jump")] [SerializeField] private float maxJumpHeight = 4;
    [SerializeField] private float timeToJump = .3f;

    [Header("Dash")] [SerializeField] private float dashDistance = 5;
    [SerializeField] private float dashTime = .2f;
    [SerializeField] private float dashCooldown = 2;

    [Header("Controllers")] [SerializeField]
    private DashBarController dashBarController;

    public bool IsDashing { get; private set; }
    public bool CanDash { get; private set; } = true;

    private delegate void PlayerDelegate();
    private PlayerDelegate _jumpEvent;
    private PlayerDelegate _dashEvent;

    private CinemachineImpulseSource _impulseSource;
    private PlayerController _playerController;
    private PlayerAnimator _playerAnimator;
    private PlayerInput _playerInput;
    private Vector2 _directionInput;
    private Vector2 _velocity;
    private float _refVelocitySmoothing;
    private float _maxJumpVelocity;
    private float _gravity;

    private void Start() {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _playerController = GetComponent<PlayerController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.DirectionalInputEvent += OnDirectionInput;
        _playerInput.JumpPressedEvent += OnJumpPressed;
        _playerInput.DashPressedEvent += OnDashPressed;

        _gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJump, 2);
        _maxJumpVelocity = Mathf.Abs(_gravity) * timeToJump;
    }

    private void Update() {
        dashBarController.UpdateBarValue(dashCooldown, dashTime, IsDashing);
        CalculateVelocity();
        HandleMove();
    }

    #region HANDLERS

    private void HandleMove() {
        _playerController.Move(_velocity * Time.deltaTime);
        _playerAnimator.UpdateAnimationState(_playerController, this);
        UpdateVerticalVelocity();
    }

    private void HandleJump() {
        _velocity.y = _maxJumpVelocity;
    }

    private IEnumerator HandleDash() {
        CanDash = false;
        IsDashing = true;

        var normalizedInput = _directionInput.normalized;
        var dashVelocity = dashDistance / dashTime;

        _velocity.x = normalizedInput == Vector2.zero ? dashVelocity * _playerController.FaceDirection : normalizedInput.x * dashVelocity;
        _velocity.y = normalizedInput.y * dashVelocity;

        _impulseSource.GenerateImpulse(new Vector3(0, 40, 0));

        yield return new WaitForSeconds(dashTime);

        _velocity.x = _playerController.FaceDirection;
        _velocity.y = 0;

        IsDashing = false;

        yield return new WaitForSeconds(dashCooldown);

        CanDash = true;
    }

    #endregion

    #region EVENTS

    private void OnDirectionInput(Vector2 input) {
        _directionInput = input;
    }

    private void OnJumpPressed() {
        if (_playerController.CollisionInfo.Below) {
            HandleJump();
        }
    }

    private void OnDashPressed() {
        if (!IsDashing && CanDash) {
            StartCoroutine(HandleDash());
        }
    }

    private static void FireEvent(PlayerDelegate playerEvent) {
        playerEvent?.Invoke();
    }

    #endregion

    #region CALCULATIONS

    private void CalculateVelocity() {
        if (!IsDashing) {
            _velocity.x = _playerController.CollisionInfo.Below ? _directionInput.x * moveSpeed : _directionInput.x * (moveSpeed * accelAirborned);
            _velocity.y += _gravity * Time.deltaTime;
        }
    }

    private void UpdateVerticalVelocity() {
        if (_playerController.CollisionInfo.Below || _playerController.CollisionInfo.Above) {
            _velocity.y = 0;
        }
    }

    #endregion
}