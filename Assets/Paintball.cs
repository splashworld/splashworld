using UnityEngine;
using System.Collections;

public class Paintball : MonoBehaviour
{

    public Rigidbody rigidbody;
    public int speed;
    

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        rigidbody.velocity = transform.forward * speed;

    }
    void OnCollisionEnter(Collision newCollision)
    {


        Destroy(gameObject);
    }




    }