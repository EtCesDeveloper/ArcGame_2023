using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Flicker : MonoBehaviour {
    private Light2D _pointLight;
    private bool _isFlickering;

    private void Start() {
        _pointLight = GetComponent<Light2D>();
    }

    private void Update() {
        if (!_isFlickering) {
            StartCoroutine(FlickerLight());
        }
    }

    private IEnumerator FlickerLight() {
        _isFlickering = true;
        var intensity = Random.Range(1, 3);
        _pointLight.intensity = intensity;

        yield return new WaitForSeconds(0.05f);

        _isFlickering = false;
    }
}