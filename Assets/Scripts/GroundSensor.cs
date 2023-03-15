using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded; // variable para que el GroundSensor detecte el suelo

    void OnTriggerEnter2D(Collider2D other) //funcion para que cuando entre al suelo lo detecte, no se vaya debajo del suelo y pueda saltar
    {
        if(other.gameObject.layer == 3) // el layer es el que hemos creado dentro del unity que tiene el numero 3 podriamos ponerle tambien ("Ground")
        {
            isGrounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D other) //funcion para que cuando este en el suelo lo detecte, no se vaya debajo del suelo y pueda saltar
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other) //funcion para que cuando no este en el suelo lo detecte y no te deje hacer saltos infinitos
    {
        if(other.gameObject.layer == 3)
        {
            isGrounded = false;
        }
    }
}
