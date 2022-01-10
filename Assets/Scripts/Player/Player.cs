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
    private int _currentWeaponNumber;
    private int _currentHealth;
    private Animator _animator;
    
    public int Money { get; private set; }

    public event UnityAction<int, int> ChangedHealth;
    public event UnityAction<int> ChangedMoney;

    private void Start()
    {
        _currentWeaponNumber = 0;
        ChangeWeapon(_weapons[_currentWeaponNumber]);
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

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
