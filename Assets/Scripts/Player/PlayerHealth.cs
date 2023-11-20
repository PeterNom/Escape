using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;

    [Header("Health Bar")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;

    [Header("Damage Overlay")]
    public Image Overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        //Overlay.color = new Color(Overlay.color.r, Overlay.color.g, Overlay.color.b, 1);
    }

    public void HealDamage(float healthAmount)
    {
        health += healthAmount;
        lerpTimer = 0f;
    }
}
