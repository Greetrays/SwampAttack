using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _tamplate;
    [SerializeField] private Transform _container;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_tamplate, _container.transform);
        view.SellButtonClick += OnClickBuyButton;
        view.Render(weapon);
    }

    private void OnClickBuyButton(Weapon weapon, WeaponView weaponView)
    {
        TryBuyedWeapon(weapon, weaponView);
    }

    private void TryBuyedWeapon(Weapon weapon, WeaponView weaponView)
    {
        if (_player.Money >= weapon.Price)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.SellButtonClick -= OnClickBuyButton;
        }
        else
        {
            Debug.Log("Недостаточно средств");
        }
    }
}
