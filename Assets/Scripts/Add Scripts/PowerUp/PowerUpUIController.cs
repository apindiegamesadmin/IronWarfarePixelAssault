using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUIController : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform[] rectTransforms;
    [SerializeField] private GameObject powerUpIcon;
    

    




     void Start()
    {
       
        rectTransform = GetComponent<Slider>().fillRect;
        rectTransforms = GetComponentsInChildren<RectTransform>();
        
    }
    void Update()
    {
        
        for (int i = 0; i < rectTransforms.Length; i++)
        {
            if (SpeedUpControl.speedUp == true)
            {
              //  slider.fillRect = rectTransforms[1];
                rectTransform = rectTransforms[1];
                powerUpIcon.SetActive(true);
            }

            if (SpeedUpControl.speedUp == false)
            {
                rectTransform = rectTransforms[0];
                powerUpIcon.SetActive(false);
            }
        }
        
    }


}
