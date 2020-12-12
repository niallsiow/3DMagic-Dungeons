using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{

    CursorLockMode lockMode;

    private void Awake()
    {
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
