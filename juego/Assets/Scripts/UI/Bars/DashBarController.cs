using UnityEngine;
using UnityEngine.UI;

public class DashBarController : MonoBehaviour {
    private RectTransform _transform;
    private RectMask2D _mask;

    private float _refVelocity;

    private void Start() {
        _transform = GetComponent<RectTransform>();
        _mask = GetComponent<RectMask2D>();
    }

    public void UpdateBarValue(float dashCooldown, float dashTime, bool isDashing) {
        var padding = _mask.padding;

        padding.z = !isDashing
            ? Mathf.SmoothDamp(padding.z, 0, ref _refVelocity, dashCooldown / (dashCooldown + 1))
            : Mathf.SmoothDamp(padding.z, _transform.rect.width, ref _refVelocity, dashTime / (dashTime + 1));

        _mask.padding = padding;
    }
}