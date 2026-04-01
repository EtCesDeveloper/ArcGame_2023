using UnityEngine;

[RequireComponent(typeof(Player), typeof(PlayerController))]
public class PlayerAnimator : MonoBehaviour {
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsFalling = Animator.StringToHash("isFalling");
    private static readonly int IsDashing = Animator.StringToHash("isDashing");

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start() {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateAnimationState(PlayerController playerController, Player player) {
        _animator.SetBool(IsRunning, playerController.IsRunning);
        _animator.SetBool(IsJumping, playerController.IsJumping);
        _animator.SetBool(IsFalling, playerController.IsFalling);
        _animator.SetBool(IsDashing, player.IsDashing);

        _spriteRenderer.flipX = playerController.FaceDirection == -1;
    }
}