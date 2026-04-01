using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour {
    protected const float SkinWidth = .015f;
    
    protected RayOrigins RaycastOrigins;
    protected float VerticalRaySpacing, HorizontalRaySpacing;
    protected int HorizontalRayCount = 4, VerticalRayCount = 4;

    private BoxCollider2D _boxCollider;

    protected virtual void Start() {
        _boxCollider = GetComponent<BoxCollider2D>();

        CalculateRaySpacing();
    }

    private void CalculateRaySpacing() {
        var bounds = _boxCollider.bounds;
        bounds.Expand(SkinWidth * -2);

        // Queremos que por lo menos se casteen 2 rayos, por eso se usa Mathf.Clamp (Restringe los valores)
        HorizontalRayCount = Mathf.Clamp(HorizontalRayCount, 2, int.MaxValue);
        VerticalRayCount = Mathf.Clamp(VerticalRayCount, 2, int.MaxValue);

        HorizontalRaySpacing = bounds.size.y / (HorizontalRayCount - 1);
        VerticalRaySpacing = bounds.size.x / (VerticalRayCount - 1);
    }

    protected void UpdateRaycastOrigins() {
        var bounds = _boxCollider.bounds;
        bounds.Expand(SkinWidth * -2);

        RaycastOrigins.TopLeft = new Vector2(bounds.min.x, bounds.max.y);
        RaycastOrigins.TopRight = new Vector2(bounds.max.x, bounds.max.y);
        RaycastOrigins.BottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        RaycastOrigins.BottomRight = new Vector2(bounds.max.x, bounds.min.y);
    }

    protected struct RayOrigins {
        public Vector2 TopLeft, TopRight;
        public Vector2 BottomLeft, BottomRight;
    }
}