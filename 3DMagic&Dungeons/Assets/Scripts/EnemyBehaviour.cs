using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;

    CharacterController controller;

    bool playerExists = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(References.playerPosition != null)
        {
            playerExists = true;
        }

        if (playerExists == true)
        {
            Vector3 targetPosition = References.playerPosition;
            Vector3 movementVector = targetPosition - transform.position;
            movementVector = movementVector.normalized;

            controller.Move(movementVector * speed * Time.deltaTime);
        }
    }
}
