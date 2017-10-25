using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour {
    //we're going to simplify this by using Quake shooting
    //i.e. you can continuously fire all guns (but they all have different fire rates)
    // Use this for initialization
    public GameObject projectileToFire;
    public float fireRate; // fire rate = bullets per minute
    private Camera weaponCamera;
    private bool weaponReady;
    private bool gunEnabled;
    void Start()
    {
        weaponReady = true;
        weaponCamera = GetComponentInParent<Camera>();
    }
    public void setGunEnabled(bool gunState)
    {
        gunEnabled = gunState;
    }
	void FixedUpdate () {
        
        if (Input.GetKey(KeyCode.Mouse0) && gunEnabled && weaponReady)
        {
            //this whole section only took me an hour to figure out 
            //NOTE TO SELF: CAMERA SCREEN TO WORLD POINT VERY USEFUL
            //half the screen width and screen height = centre of the screen
            //use your own z position, but make it the local one
            GameObject projectile = Instantiate(projectileToFire,
                weaponCamera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, (transform.localPosition.z + .5f))), weaponCamera.transform.rotation);
            projectile.GetComponent<Rigidbody>().velocity += GetComponentInParent<Rigidbody>().velocity;
            StartCoroutine(fireRateDelay());
        }
	}
    IEnumerator fireRateDelay()
    {
        weaponReady = false;
        yield return new WaitForSeconds(60 / fireRate);
        weaponReady = true;
    }
}
