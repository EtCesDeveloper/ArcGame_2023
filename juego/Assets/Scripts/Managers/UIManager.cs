using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager> {
    [Header("Pick Up")] [SerializeField] public GameObject visualObject;
    [Header("Texts")] [SerializeField] private TextMeshProUGUI potionsText;

    private Canvas _canvas;

    private void Start() {
        _canvas = FindObjectOfType<Canvas>();
    }

    public void ChangePotionText(int potions) {
        potionsText.text = potions + "/1";
    }

    // Devuelve, además de instanciar un GameObject para destruirlo en otra clase.
    public GameObject OnEnterPickUpItem(GameObject itemToPickUp) {
        if (Camera.main != null) {
            var spawnPosition = Camera.main.WorldToScreenPoint(itemToPickUp.transform.position + new Vector3(0, 2, 0));

            return Instantiate(visualObject, spawnPosition, Quaternion.identity, _canvas.transform);
        }

        return null;
    }
}