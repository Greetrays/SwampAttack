using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected int MaxBullets; 
    [SerializeField] protected Bullet Bullet;

    protected int CurrentRemainingBullets;

    public event UnityAction<int, int> Shooted;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public int MaxCountBullets => MaxBullets;
    public int CurrentRemainingCountBullets;

    public virtual void Shoot(Transform shootPoint, Vector3 targetPoint)
    {
        Shooted?.Invoke(CurrentRemainingBullets, MaxBullets);
    }

    public void Buy()
    {
        _isBuyed = true;
    }

    private void OnValidate()
    {
        if(CurrentRemainingBullets != MaxBullets)
        {
            CurrentRemainingBullets = MaxBullets;
        }
    }
}
