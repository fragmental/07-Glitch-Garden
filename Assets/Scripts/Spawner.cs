using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] attackerPrefabArray;


	void Update ()
    {

		foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                //Debug.Log("Hey");
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float SpawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = SpawnsPerSecond * Time.deltaTime/5;
        /*if(Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
        */
        //The line below replaces the commented lines above.
        return (Random.value < threshold);

        
    }
}
