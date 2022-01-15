using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _iconWeapon;

    private void OnEnable()
    {
        _player.ChangedWeapon += Render;
    }

    private void OnDisable()
    {
        _player.ChangedWeapon -= Render;
    }

    private void Render(Weapon weapon)
    {
        _iconWeapon.sprite = weapon.Icon;
    }
}
