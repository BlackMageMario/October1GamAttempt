using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float forwardSpeed;
    public float backwardSpeed;
    public float sideWaySpeed;
    public float jumpSpeed;
    public FireWeapon gun;
    private Camera bodyCamera;
    private Rigidbody body;
    private GameObject flashLight;
	void Start () {
        body = GetComponent<Rigidbody>();
        bodyCamera = GetComponentInChildren<Camera>();
        flashLight = GameObject.Find("Flashlight");
        gun.setGunEnabled(false);
	}
	void FixedUpdate () {
        body.transform.rotation = new Quaternion(body.transform.rotation.x, bodyCamera.transform.rotation.y,
            body.transform.rotation.z, bodyCamera.transform.rotation.w);
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(body.transform.forward * forwardSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(-body.transform.forward * backwardSpeed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            body.AddForce(-body.transform.right * sideWaySpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            body.AddForce(body.transform.right * sideWaySpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(this.transform.position, Vector3.down, 1f))
        {
            body.AddForce(Vector3.up  * jumpSpeed);
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            //flip state of flashlight and gun
            Debug.Log("Flashlight");
            //so this is confusing
            //basically: set the flashlight's active state to the opposite state. So if the flashlight is on, turn it off
            //then set the gun's active state to the opposite state of the flashlight. So if the flasight goes from off to on
            //the gun goes from on to off
            flashLight.gameObject.SetActive(!flashLight.gameObject.activeSelf);
            gun.setGunEnabled(!flashLight.gameObject.activeSelf);
        }
    }
}
