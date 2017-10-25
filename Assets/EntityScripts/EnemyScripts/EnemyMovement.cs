using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float forwardVelocity;
    public float backwardVelocity;
    public float sidewayVelocity;
    public float attackDistance;
    public float detectDistance;
    public float wanderX, wanderY;
    protected GameObject target;
    protected Rigidbody body;
    protected EnemyAttack attack;
    protected Vector3 randomWanderPoint;
    //why do i alwayss start these off as movement scripts
    //and then make them behaviour scripts
    //hint... because you aren't adding in the state manager yet :V
    //what else do all enemies need
    //some way to detect when close to player
    //possibly raycasts - actually that doesn't work well *at all*
    //a very basic movement behaviour
	// Use this for initialization
	protected virtual void Start () {
        target = GameObject.Find("PlayerObject");
        body = GetComponent<Rigidbody>();
        attack = GetComponent<EnemyAttack>();
        StartCoroutine(generateRandomWanderPoint());
    }
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
        if (target)//if we have a target
        {
            if (Vector3.Distance(target.transform.position, body.transform.position) <= detectDistance)
            {
                Vector3 direction = (target.transform.position - body.transform.position).normalized;
                body.transform.LookAt(target.transform.position);
                //body.transform.LookAt(new Vector3(target.transform.position.x, 0, target.transform.position.z));
                if (Vector3.Distance(target.transform.position, body.transform.position) <= attackDistance)
                {
                    //raycasts were not working, wonder why
                    attack.attack(target);//such descriptive and useful names

                }
                else
                {
                    Debug.Log("Moving");
                    body.AddForce(direction * forwardVelocity);
                }
            }
            else
            {
                //wander randomly
                Vector3 direction = (randomWanderPoint - body.transform.position).normalized;
                body.AddForce(direction * forwardVelocity);
            }
        }
        
	}
    protected IEnumerator generateRandomWanderPoint()
    {
        Random.InitState((int)Time.unscaledTime);
        while (true)
        {
            randomWanderPoint = new Vector3(Random.Range(-100, 100), transform.position.y, Random.Range(-100, 100));
            yield return new WaitForSeconds(.2f);
        }
    }

}
