using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyToSpawn;
    public GameObject target;
    public GameObject spawnPoint;
    public TriggerAction action;
    public int numberToSpawn;
    private int currNumAlive;
    //won't go with object pooling this time
    //public ActionScript toExecute
	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("lmao?");
        if (other.gameObject.Equals(target))
        {
            Debug.Log("Did we get here?");
            for (int i = 0; i < numberToSpawn; i++)
            {   
                spawnEnemy();
            }
            currNumAlive = numberToSpawn;
        }
    }
    private void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
        if(spawnPoint)
        {
            enemy.transform.position = spawnPoint.transform.position;
        }
        enemy.AddComponent<EnemySpawnerInstance>();
    }

    public void enemyDiedMessage()
    {
        currNumAlive--;
        if(currNumAlive <= 0)
        {
            action.executeAction();
            //all enemies died
            //now we need to execute the action of the script attached, if there is one
            Destroy(gameObject); //manual garbage collection :^)
        }
    }

}

public class EnemySpawnerInstance : MonoBehaviour
{
    public EnemySpawner theSpawner;
    public void reportDead()
    {
        //report the enemy as dead
        theSpawner.enemyDiedMessage();
    }
    //this is ust a pattern i saw once from unity
    //... I can't tell if this is good or not.
}
