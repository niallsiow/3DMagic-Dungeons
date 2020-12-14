﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float speed;

    Vector3 bulletTransform;

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
}
