using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //[SerializeField]
    Vector2 displacement;
    [SerializeField] Vector2 velocity;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        displacement = velocity * Time.deltaTime;
        transform.position = transform.position + new Vector3(displacement.x, displacement.y, 0);
    }
}
