using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Player player;
    
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x,  10f, player.transform.position.z - 20f);
    }

}