using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public int maxHealth;
    //no armour going to be used for this
    //just pure health
    //but we might as well have damage resist as well
    
    protected int currentHealth;
	// Use this for initialization
	protected virtual void Start () {
        currentHealth = maxHealth;
	}
    public virtual void takeDamage(int damage)
    {
        Debug.Log("Before damage: " + currentHealth);
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            //rip
            //disable i suppose for now
            deathAction();
        }
        Debug.Log("After damage: " + currentHealth);
    }
    protected virtual void deathAction()
    {
        //do something on death
        gameObject.SetActive(false);
    }

}
