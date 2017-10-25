using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float velocity;
    public int damage;//damage of the projectile (for later)
    protected float timeUntilDisable = 4.5f;
    private Rigidbody body;
    //all basic projectiles will do this
	protected virtual void Start () {
        body = GetComponent<Rigidbody>();
        StartCoroutine(disableAfterCertainTime());
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
        body.AddForce(transform.forward * velocity);
	}

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (!(other.name == this.name) && other.name != "PlayerObject")//ie if they are not the same
        {
            Debug.Log(other.name);
            HealthManager manager = other.GetComponent<HealthManager>();
            if(manager)
            {
                manager.takeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    protected virtual IEnumerator disableAfterCertainTime()
    {
        yield return new WaitForSeconds(timeUntilDisable);
        Destroy(gameObject);
    }

}
