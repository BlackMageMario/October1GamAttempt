using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : HealthManager {
    [Range(0f, 0.90f)]public float maxDamResist;
    public Slider healthSlider;
    public Slider armourSlider;
    public Text message;
    public FireWeapon gun;
    private string gameOver = "Game Over!";
    private float currentDamageResist;
    protected override void Start () {
        base.Start();
        currentDamageResist = maxDamResist;
        healthSlider.maxValue = maxHealth;
        armourSlider.maxValue = maxDamResist;
        updateSliders();
	}

    // Update is called once per frame
    public override void takeDamage(int damage)
    {
        currentHealth -= (int)(damage - (damage * currentDamageResist));
        currentDamageResist -= (damage * currentDamageResist);
        currentDamageResist = Mathf.Clamp(currentDamageResist, 0, maxDamResist);
        //makes sure the damage resist cannot go below 0
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            GetComponentInChildren<Camera>().transform.SetParent(null);
            message.text = gameOver;
            gun.setGunEnabled(false);
            gameObject.SetActive(false);
        }
        updateSliders();
    }
    private void updateSliders()
    {
        healthSlider.value = currentHealth;
        armourSlider.value = currentDamageResist;
    }
}
