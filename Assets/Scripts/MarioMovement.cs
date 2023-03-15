using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public float jumpForce = 3f; // variable de la fuerza de salto
    public float playerSpeed = 5.5f; // variable de la velocidad del personaje
    float horizontal; // variable para que podamos movernos y girar el sprite


    private GroundSensor sensor; // variable para que podamos detectar el script del ground sensor
    private Rigidbody2D rBody; // variable para que podamos detectar el RigidBody2D
    private SpriteRenderer spriteRenderer; // variable para que podamos girar el sprite


    // Start is called before the first frame update
    void Start()
    {
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>(); // funciones para encontrar el script y usar-lo
        rBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); // funcion para que se gire el sprite

        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        if(Input.GetButtonDown("Jump") && sensor.isGrounded)  // funcion para el salto
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    void FixedUpdate() // funcion para tener la velocidad del mario
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);    
    }
}
