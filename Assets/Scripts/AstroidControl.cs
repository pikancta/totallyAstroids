using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidControl : MonoBehaviour
{
    public int pointValue;
    public gameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(pointValue);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
