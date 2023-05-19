using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private CharacterController controller;
    private Animator anim;
    private float speed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<CharacterController>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        if(controller.isGrounded) {            
            Vector3 moveVector = Vector3.zero;
            Vector3 targetPosition = transform.position.y * Vector3.up * 50f;            
            moveVector.y = (targetPosition - transform.position).normalized.y * speed;            
            anim.SetTrigger("jump");
            controller.Move(moveVector * Time.deltaTime);
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
    }

}