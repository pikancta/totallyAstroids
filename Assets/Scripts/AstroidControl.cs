using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidControl : MonoBehaviour
{
    public int pointValue;
    public gameManager gm;
    public Rigidbody rb;

    public GameObject smallerAstroid;
    public int smallerAstroidsToSpawn;

    public float forceRange;
    public float torqueRange;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        rb = GetComponent<Rigidbody>();

        AddRandomForce();
        AddRandomtorque();
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
            gm.PlayerDie ();
            Destroy(collision.gameObject);
        }
    }

    private void SpawnSmaller(int numberToSpawn)
    {
        if (smallerAstroid != null)
        {
            for (int i = 0; i < numberToSpawn; i++)
            {
                Instantiate(smallerAstroid, transform.position, transform.rotation);
            }
        }
    }

    public void AddRandomForce()
    {
        float randomForceX = Random.Range(-forceRange, forceRange);
        float randomForceZ = Random.Range(-forceRange, forceRange);
        Vector3 randomForce = new Vector3(randomForceX, randomForceZ);

        rb.AddForce(randomForce, ForceMode.Impulse);
    }

    public void AddRandomtorque()
    {
        float randomTorque = Random.Range(-torqueRange, torqueRange);
        rb.AddTorque(Vector3.back * randomTorque, ForceMode.Impulse);
    }
}
