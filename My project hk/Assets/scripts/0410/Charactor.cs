using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    float rotSpeed = 0;
    // Start is called before the first frame update
 

    // Update is called once per frame1212
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.rotSpeed = 10000;
        }

        transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);

        rotSpeed *= 0.99f;
    }
}
