using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))] 

public abstract class Bar : MonoBehaviour
{
    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    protected void OnChangedValue(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
