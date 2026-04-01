using UnityEngine;

public class PlayerController : RaycastController {
    [SerializeField] private LayerMask collisionMask;

    public CollisionData CollisionInfo;

    public int FaceDirection { get; private set; }
    public bool IsRunning { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsFalling { get; private set; }

    protected override void Start() {
        base.Start();
        FaceDirection = 1;
    }

    public void Move(Vector2 velocity) {
        UpdateRaycastOrigins();
        CollisionInfo.Reset();

        if (velocity.x != 0) {
            FaceDirection = (int) Mathf.Sign(velocity.x);
        }

        CheckHorizontalCollisions(ref velocity);

        if (velocity.y != 0) {
            CheckVerticalCollisions(ref velocity);
            IsJumping = velocity.y > 0;
            IsFalling = velocity.y < -0.015f;
        }

        IsRunning = velocity.x != 0;

        transform.Translate(velocity);
    }

    private void CheckVerticalCollisions(ref Vector2 velocity) {
        var directionY = Mathf.Sign(velocity.y);
        var rayLength = Mathf.Abs(velocity.y) + SkinWidth;

        for (var i = 0; i < VerticalRayCount; i++) {
            var rayOrigin = directionY.Equals(-1) ? RaycastOrigins.BottomLeft : RaycastOrigins.TopLeft;
            rayOrigin += Vector2.right * (VerticalRaySpacing * i + velocity.x);

            var hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            if (hit) {
                velocity.y = 0;
                rayLength = 0;

                CollisionInfo.Above = directionY.Equals(1);
                CollisionInfo.Below = directionY.Equals(-1);
            }
        }
    }

    private void CheckHorizontalCollisions(ref Vector2 velocity) {
        var directionX = FaceDirection;
        var rayLength = Mathf.Abs(velocity.x) + SkinWidth;

        for (var i = 0; i < HorizontalRayCount; i++) {
            var rayOrigin = directionX == 1 ? RaycastOrigins.BottomRight : RaycastOrigins.BottomLeft;
            rayOrigin += Vector2.up * (HorizontalRaySpacing * i);

            var hit = Physics2D.Raycast(rayOrigin, Vector2.right * (directionX * rayLength), rayLength, collisionMask);

            if (hit) {
                velocity.x = 0;
                rayLength = 0;

                CollisionInfo.Left = directionX.Equals(-1);
                CollisionInfo.Right = directionX.Equals(1);
            }
        }
    }

    public struct CollisionData {
        public bool Above, Below;
        public bool Left, Right;

        public void Reset() {
            Above = Below = Left = Right = false;
        }
    }
}