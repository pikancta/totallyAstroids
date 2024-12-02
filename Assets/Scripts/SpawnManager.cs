using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public gameManager gm;
    public float horizontalRange;
    public float verticalRange;
    public GameObject Ship;

    public GameObject asteriod;
    public int asteriodsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        Ship = GameObject.Find("Ship");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Asteriod").Length <= 0)
        {
            SpawnWave(asteriodsToSpawn);
        }
    }

    public Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        float randomZ = Random.Range(-verticalRange, verticalRange);
        Vector3 randomPos = new Vector3(randomX, 0, randomZ);

        while((randomPos - Ship.transform.position).magnitude < gm.safetyRadius)
        {

            randomX = Random.Range(-horizontalRange, horizontalRange);
            randomZ = Random.Range(-verticalRange, verticalRange);
            randomPos = new Vector3(randomX, 0, randomZ);
        }

        return randomPos;
    }

    public void SpawnWave(int asteriod)
    {
        for(int i = 0; i < asteriod; i ++)
        {
            //Instantiate(asteriod, GenerateRandomPosition(), transform.rotation);
        }
    }
}
