using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick joystick;
    private CharacterController controller;
    private Animator anim;
    public float speed = 10f;
    public float turnSmoothTime = 1f;
    private float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.inputDir != Vector2.zero) {
            float x = joystick.inputDir.x;
            float y = joystick.inputDir.y;
            Vector3 direction = (Vector3.forward * y) + (Vector3.right * x);                     
            controller.transform.rotation = Quaternion.LookRotation(direction);
            controller.transform.Translate(direction * (1f * Time.deltaTime));
            anim.SetTrigger("run");
            controller.Move(direction * speed * Time.deltaTime);              
        }
        else {
            anim.SetTrigger("idle");
        }
    }

}