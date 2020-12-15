using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    CharacterController controller;

    public Transform cam;

    public float speed;
    public float jumpHeight;

    public float turnSmoothTime;
    float turnSmoothVelocity;

    public GameObject bulletPrefab;

    public Transform firePosition;


    Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        References.playerPosition = transform.position;

        // movement code
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.01f)
        {
            // rotate the player towards camera position when forward pressed
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // rotate input vector relative to camera position so player movement is relative to camera position
            Vector3 inputVector = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * direction;
            controller.Move(inputVector * speed * Time.deltaTime);
            
        }

        // jumping and gravity application
        float gravityValue = -9.81f;

        if (controller.isGrounded == true)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            playerVelocity.y += jumpHeight;
        }

        controller.Move(playerVelocity * Time.deltaTime);


        // shoot when left click pressed
        if (Input.GetButtonDown("Fire1"))
        {

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;


            Vector3 hitPoint;
            Vector3 bulletVector;

            if (Physics.Raycast(ray, out hit))
            {
                hitPoint = hit.point;
                bulletVector = (hitPoint - firePosition.position).normalized;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePosition.position, transform.rotation);
                bullet.GetComponent<BulletBehaviour>().SetTransform(bulletVector);
            }
            else
            {
                hitPoint = ray.GetPoint(100);
                bulletVector = (hitPoint - firePosition.position).normalized;

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, firePosition.position, transform.rotation);
                bullet.GetComponent<BulletBehaviour>().SetTransform(bulletVector);
            }


        }

    }
}