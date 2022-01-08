using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChangedMoney += OnChangedMoney;
        _money.text = _player.Money.ToString();
    }

    private void OnDisable()
    {
        _player.ChangedMoney -= OnChangedMoney;
    }

    private void OnChangedMoney(int money)
    {
        _money.text = money.ToString();
    }
}
