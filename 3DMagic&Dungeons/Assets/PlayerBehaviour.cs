using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    CharacterController controller;

    public Transform cam;

    public float speed;

    public float turnSmoothTime;
    float turnSmoothVelocity;

    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // forward move direction should only impact the movement vector if there is a vertical input
            // Vector3 forwardMoveVector = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * Vector3.forward * direction.z;

            // Vector3 forwardMoveVector = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * Vector3.forward * direction.z;

            // Vector3 inputVector = new Vector3(direction.x, 0, forwardMoveVector.z);

            Vector3 inputVector = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * direction;
            controller.Move(inputVector * speed * Time.deltaTime);
            
        }


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
        }

    }
}