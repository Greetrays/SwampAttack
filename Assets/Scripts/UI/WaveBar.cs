using UnityEngine;

public class WaveBar : Bar
{
    [SerializeField] private SpawnerEnemy _spawner;

    private void OnEnable()
    {
        _spawner.ChangedWave += OnChangedValue;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.ChangedWave -= OnChangedValue;
    }
}
