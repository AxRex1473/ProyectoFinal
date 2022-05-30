using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float VerSpeed;
    public float HorSpeed;
    public float speed;

    float x;
    float z;

    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPersonaje();
        RotarCamera();
    }

    public void MovimientoPersonaje()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    public void RotarCamera()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }

    }
}
