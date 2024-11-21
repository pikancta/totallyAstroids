using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidControl : MonoBehaviour
{
    public int pointValue;
    public gameManager gm;

    public GameObject smallerAstroid;
    public int smallerAstroidsToSpawn;

    public float forceRange;

    private void Start()
    {
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(pointValue);
            Destroy(collision.gameObject);
            SpawnSmaller(smallerAstroidsToSpawn);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void SpawnSmaller(int numberToSpawn)
    {
        if(smallerAstroid != null)
        {
            for(int i = 0; i < numberToSpawn; i++)
            {
                Instantiate(smallerAstroid, transform.position, transform.rotation);
            }
        }
    }

    public void AddRandomForce()
    {
        float randomForceX = Random.Range(-forceRange, forceRange);
        float randomForceY = Random.Range(-forceRange, forceRange);
        Vector3 randomForce = new Vector3(randomForceX, randomForceY);
    }
}
