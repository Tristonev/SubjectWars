using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 15;

        //move camera right
        if (Input.GetKey(KeyCode.D) && transform.position.x < 18)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        //move camera left
        if (Input.GetKey(KeyCode.A) && transform.position.x > -2)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
