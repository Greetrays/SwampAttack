using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _target;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> ChangedWave;
    private Wave _currentWave;
    private int _currentWaweNumber;
    private float _elapsedTimeLastSpawn;
    private int _spawnedCount;

    private void Start()
    {
        SetWave(_currentWaweNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _elapsedTimeLastSpawn += Time.deltaTime;

        if (_elapsedTimeLastSpawn > _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawnedCount++;
            ChangedWave?.Invoke(_spawnedCount, _currentWave.CountEnemy);
            _elapsedTimeLastSpawn = 0;
        }

        if (_spawnedCount >= _currentWave.CountEnemy)
        {
            if (_waves.Count > _currentWaweNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    public void OnEnemyDying(Enemy enemy)
    {
        Debug.Log(1);
        _target.AddMoney(enemy.Reward);
        enemy.Dying -= OnEnemyDying;
    }

    public void NextWave()
    {
        SetWave(++_currentWaweNumber);
        _spawnedCount = 0;
        ChangedWave?.Invoke(_spawnedCount, _currentWave.CountEnemy);
    }

    private void InstantiateEnemy()
    {
            Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
            enemy.SetTarget(_target);
            enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int indexWave)
    {
        _currentWave = _waves[indexWave];
    }
}

[System.Serializable]

public class Wave
{
    [SerializeField] public Enemy Template;
    [SerializeField] public int CountEnemy;
    [SerializeField] public float Delay;
}