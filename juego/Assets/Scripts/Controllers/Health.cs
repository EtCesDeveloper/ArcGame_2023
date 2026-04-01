using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
    [SerializeField] private int maxHealth = 100;

    public UnityEvent<int> healed;
    public UnityEvent<int> damaged;
    public UnityEvent dead;

    public int HealthPoints {
        get => _healthPoints;
        private set {
            var isDamage = value < _healthPoints;
            _healthPoints = Mathf.Clamp(_healthPoints, 0, maxHealth);

            if (isDamage) {
                damaged?.Invoke(_healthPoints);
            } else {
                healed?.Invoke(_healthPoints);
            }

            if (_healthPoints <= 0) dead?.Invoke();
        }
    }

    public int MaxHealthPoints => maxHealth;

    private int _healthPoints;

    private void Awake() {
        _healthPoints = maxHealth;
    }

    public void Damage(int amount) => HealthPoints -= amount;
    public void HealFull() => HealthPoints = maxHealth;
    public void Kill() => HealthPoints = 0;
}