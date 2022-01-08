using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;
    
    public int Money { get; private set; }

    public event UnityAction<int, int> ChangedHealth;
    public event UnityAction<int> ChangedMoney;

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _weapons[0].Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        ChangedHealth?.Invoke(_currentHealth, _maxHealth);
        
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        ChangedMoney?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        ChangedMoney?.Invoke(Money);
    }
}
