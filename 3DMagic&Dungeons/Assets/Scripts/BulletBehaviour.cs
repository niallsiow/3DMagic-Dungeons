using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float speed;
    public float damage;

    Vector3 bulletTransform;

    bool collided = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += bulletTransform * speed * Time.deltaTime;
    }

    public void SetTransform(Vector3 inputTransform)
    {
        bulletTransform = inputTransform;
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherCollider = collision.gameObject;
        if (otherCollider.tag == "Enemy" && collided == false)
        {
            otherCollider.GetComponent<HealthSystem>().TakeDamage(damage);
            Debug.Log("enemy hit");
        }

        collided = true;

        Destroy(gameObject);
    }
}