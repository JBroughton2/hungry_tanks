using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private Rigidbody rb;
    private string movementAxis;
    private string turnAxis;
    private float movementInput;
    private float turnInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        movementAxis = "Vertical";
        turnAxis = "Horizontal";
    }


    private void Update()
    {
        movementInput = Input.GetAxis(movementAxis);
        turnInput = Input.GetAxis(turnAxis);
  
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * movementInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        print(movementInput);
    }

    private void Turn()
    {
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * rotation);
    }

    private void StationaryTurn()
    {
        float slowTurn = turnInput * 20 * Time.deltaTime;
        Quaternion statRotation = Quaternion.Euler(0, slowTurn, 0);
        rb.MoveRotation(rb.rotation * statRotation);
    }
}
