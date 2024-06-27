using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Health _health;
    [SerializeField] private MovingBar _movingBarType;
    [SerializeField] private float _changingSpeed;

    private float _target;

    private void Awake()
    {
        _health.HealthChanged += UpdateBar;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= UpdateBar;
    }

    public void UpdateBar()
    {
        _target = _health.CurrentValue / _health.MaxValue;
    }

    private void Update()
    {
        if (_movingBarType == MovingBar.Gradually)
        {
            _image.fillAmount = Mathf.Clamp(_image.fillAmount, _target, _changingSpeed * Time.deltaTime);
        }
        else
        {
            _image.fillAmount = _target;
        }
    }
}

enum MovingBar
{
    Instantly,
    Gradually
}