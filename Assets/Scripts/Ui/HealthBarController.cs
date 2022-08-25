using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Image healthBarImage;
    [SerializeField] Gradient gradientColor;
    Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeColor()
    {
        healthBarImage.color = gradientColor.Evaluate(slider.value);
    }
}
