using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float cameraXMovement;
    private float cameraX;
    private float cameraY;
    private GameObject flashLight;
    // Use this for initialization
    void Start() {
        flashLight = GameObject.Find("Flashlight");
    }
	
	// Update is called once per frame
	void Update () {
        cameraXMovement = Input.GetAxis("Mouse X");
        cameraX += cameraXMovement;
        cameraY -= Input.GetAxis("Mouse Y");
        if (cameraY > 90)
        {
            cameraY = 89;
        }
        if (cameraY < -90)
        {
            cameraY = -89;
        }
        transform.eulerAngles = new Vector3(Mathf.Clamp(cameraY, -90, 90),
            cameraX, transform.eulerAngles.z);
        if(flashLight.activeSelf)
        {
            flashLight.transform.position = GetComponent<Camera>().ScreenToWorldPoint(
                new Vector3(Screen.width / 2, Screen.height / 2, 
                    flashLight.transform.localPosition.z));
            flashLight.transform.eulerAngles = new Vector3(Mathf.Clamp(cameraY, -90, 90),
               cameraX, flashLight.transform.eulerAngles.z);
        }
    }
}
