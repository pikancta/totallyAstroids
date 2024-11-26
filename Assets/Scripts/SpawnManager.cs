using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public gameManager gm;
    public float horizontalRange;
    public float verticalRange;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        float randomZ = Random.Range(-verticalRange, verticalRange);
        Vector3 randomPos = new Vector3(randomX, 0, randomZ);

      //  while((randomPos - ship.transform.position).magnitude < gm.safetyRadius)

        return randomPos;
    }
}
