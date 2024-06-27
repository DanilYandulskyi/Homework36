using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    public float CurrentValue { get; private set; }
    public float MaxValue => _maxValue;
    public event Action HealthChanged;

    public void Start()
    {
        CurrentValue = _maxValue;
        HealthChanged?.Invoke();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Decrease(1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Increase(1);
        }
    }

    public void Decrease(int value)
    {
        if (value < 0)
        {
            return;
        }

        if ((CurrentValue -= value) <= 0)
        {
            Destroy(gameObject);
        }

        HealthChanged?.Invoke();
    }

    public void Increase(int value)
    {
        if (value < 0)
        {
            return;
        }

        CurrentValue += value;

        if (CurrentValue >= _maxValue)
        {
            CurrentValue = _maxValue;
        }

        HealthChanged?.Invoke();
    }
}
