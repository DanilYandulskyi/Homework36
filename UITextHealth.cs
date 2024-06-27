using UnityEngine;
using TMPro;

public class UITextHealth : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        _health.HealthChanged += UpdateText;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= UpdateText;
    }

    private void UpdateText()
    {
        _text.text = $"{_health.CurrentValue} / {_health.MaxValue}";
    }
}
