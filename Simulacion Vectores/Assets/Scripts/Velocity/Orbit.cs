using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class Orbit : MonoBehaviour
{
    //[SerializeField]
    Vector3 displacement;
    [SerializeField] Vector3 velocity, aceleration, damping;
    Transform trans;

    [SerializeField] GameObject center;

    [Header("Game borders")]
    [SerializeField] float yBorder;
    [SerializeField] float xBorder;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
        CheckCollision();
    }

    public void Move()
    {
        aceleration = center.transform.position - trans.position;
        velocity += aceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + displacement;

        aceleration.Draw(transform.position, Color.blue);
        velocity.Draw(transform.position, Color.green);
        transform.position.Draw(Color.red);
    }

    private void CheckCollision()
    {
        if (transform.position.x >= xBorder || transform.position.x <= -xBorder)
        {
            if (transform.position.x <= -xBorder) trans.position = new Vector3(-xBorder, trans.position.y, 0);
            else if (transform.position.x >= xBorder) trans.position = new Vector3(xBorder, trans.position.y, 0);
            velocity.x = velocity.x * -1;
            velocity.x = velocity.x - damping.x;
            //aceleration.x *= -1;
        }
        else if (transform.position.y >= yBorder || transform.position.y <= -yBorder)
        {
            if (transform.position.y <= -yBorder) trans.position = new Vector3(transform.position.x, -yBorder, 0);
            else if (transform.position.y >= yBorder) trans.position = new Vector3(transform.position.x, yBorder, 0);
            velocity.y = velocity.y * -1;
            velocity.y = velocity.y - damping.y;
            //aceleration.y *= -1;
        }
    }
}
