using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 30;
    public float horizontalInput;
    public float turnSpeed;
    public float forwardInput;
    public GameObject Bullet;

    public gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.left, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }

    }
}
