using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour {
    // if this was designed well
    // this would be a generalised interface
    // but im so out of time lmao
    public float distanceToMove;
    public float duration;
    public GameObject wallToMove;//the thing we're fucking with
	// Use this for initialization
    public void executeAction()
    {
        Debug.Log("Did it work?");
        StartCoroutine(moveWall());
    }
    private IEnumerator moveWall()
    {
        Vector3 originalPoint = wallToMove.transform.position;
        float rateOfChange = distanceToMove/duration;
        while(Vector3.Distance(originalPoint, wallToMove.transform.position) < distanceToMove)
        {
            wallToMove.GetComponent<Rigidbody>().AddForce(new Vector3(rateOfChange, 0, 0));
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }
}
