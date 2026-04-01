using UnityEngine;

public class Potion : MonoBehaviour {
    private GameObject _item;
    private int _potionsPicked;
    private bool _canPickUp;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && _canPickUp) {
            _potionsPicked++;
            PickUpItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            _item = UIManager.Instance.OnEnterPickUpItem(gameObject);
            _canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            Destroy(_item);
            _canPickUp = false;
        }
    }

    private void PickUpItem() {
        UIManager.Instance.ChangePotionText(_potionsPicked);
        Destroy(gameObject);
    }
}