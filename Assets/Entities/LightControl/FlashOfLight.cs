using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOfLight : MonoBehaviour {
    public float duration;//not in seconds - not sure what it is in
    public float defaultIntensity;
    private float maxIntensity;
    private Light objectLight;
	// Use this for initialization
	void Start () {
        objectLight = GetComponent<Light>();
        maxIntensity = objectLight.intensity;
        objectLight.intensity = defaultIntensity;
        StartCoroutine(flashLight());
    }
    protected virtual IEnumerator flashLight()
    {
        float rateOfChange = maxIntensity / (duration);//translate into milliseconds
        while(objectLight.intensity < maxIntensity)
        {
            objectLight.intensity += rateOfChange;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (objectLight.intensity > 0)
        {
            objectLight.intensity -= rateOfChange;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        //delete when done
        Destroy(gameObject);
    }
}
