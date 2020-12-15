using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public float maxHealth;
    private float health;
    public GameObject healthBarPrefab;

    HealthBar myHealthBar;

    Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = References.mainCamera;

        health = maxHealth;

        // create our health panel on our canvas
        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBar>();

    }

    // Update is called once per frame
    void Update()
    {
        // make our health bar reflect our health
        myHealthBar.ShowHealthFraction(health / maxHealth);

        // make healthbar follow us
        myHealthBar.transform.position = myCamera.WorldToScreenPoint(transform.position + Vector3.up * 2);
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {

        Destroy(myHealthBar.gameObject);
        Destroy(gameObject);
    }
}
