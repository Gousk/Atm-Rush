using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float horizontalSpeed = 3f;
    float input;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        transform.Translate(input*horizontalSpeed*Time.deltaTime,0,movementSpeed*Time.deltaTime);

          
    }
}
