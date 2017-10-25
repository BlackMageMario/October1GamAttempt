using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public int damage;
    public float range;
    public float attackDuration;//in secondss
    public float timeBetweenAttacks;//in seconds
    public GameObject attackObject;
    protected bool canAttack = true;
    //yes i know this is horrible
    //reimplement l a t e r :u
    //types? probably not
    //could this be abstract??? for later :u
    // Use this for initialization
    //let the base implementation be a melee raycast
    protected virtual bool doAttack(GameObject target)
    {
        RaycastHit hit;
        //this is the same except with raycasts, i think we need to generate an attack animation
        if (Physics.Raycast(transform.position, (target.transform.position - transform.position).normalized, out hit, range))
        {
            if(hit.transform.gameObject.Equals(target))
            {
                HealthManager health = target.GetComponent<HealthManager>();
                health.takeDamage(damage);
                return true;
            }
        }   
        return false;
    }
    protected IEnumerator attemptAttack(GameObject target)
    {
        canAttack = false;
        float counter = 0.0f;
        bool targetHit = false;
        GameObject currentAttack = Instantiate(attackObject,
            transform.position + new Vector3(0, 0, -range/2), 
            attackObject.transform.rotation);
        currentAttack.transform.localScale = new Vector3(range, currentAttack.transform.localScale.y, currentAttack.transform.localScale.z);
        currentAttack.transform.SetParent(gameObject.transform);
        currentAttack.transform.rotation *= Quaternion.Euler((target.transform.position - transform.position).normalized);
        while (counter < attackDuration)
        {
            if (!targetHit)
            {
                targetHit = doAttack(target);
            }
            counter += Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        Destroy(currentAttack);
        StartCoroutine(pauseAttacking());
        //we don't do the attack anymore
    }
    public void attack(GameObject target)
    {
        if (canAttack)
        {
            StartCoroutine(attemptAttack(target));
        }
    }
    protected IEnumerator pauseAttacking()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        canAttack = true;
    }
    //let's rethink how melee works
    //what we want to do is, for a few frames, create a raycast / sphere / WHATEVER to attack the player
    //then detect if the player is hit by that
}

