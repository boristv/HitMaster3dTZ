using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [FormerlySerializedAs("_health")] [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Slider healthSlider;
    private GameObject healthSliderObject;
    [SerializeField] private bool showSliderAtFullHealth = true;

    private void Awake()
    {
        healthSliderObject = healthSlider.gameObject;
        healthSliderObject.SetActive(showSliderAtFullHealth);
    }

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += ShowHealth;
    }

    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= ShowHealth;
    }

    private void ShowHealth(float healthPercent)
    {
        healthSliderObject.SetActive(true);
        healthSlider.value = healthPercent;
        if(healthPercent <= 0) 
            healthSliderObject.SetActive(false);
    }
}
