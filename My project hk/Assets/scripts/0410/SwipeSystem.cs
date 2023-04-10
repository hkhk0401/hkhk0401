using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSystem : MonoBehaviour
{

    private Vector2 initialPos;
    public GameObject Charactor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) initialPos = Input.mousePosition;
        if (Input.GetMouseButtonUp(0)) Calculate(Input.mousePosition);
    }
    void Calculate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(initialPos.x  - finalPos.x);
        float disY = Mathf.Abs(initialPos.y  - finalPos.y);

        if (disX > 0 || disY > 0)
        {
            if (disX > disY)
            {
                if (initialPos.x > finalPos.x)
                {
                    Charactor.transform.position += new Vector3(-1.0f, 0.0f, 0.0f);
                }
                else
                {
                    Charactor.transform.position += new Vector3(1.0f, 0.0f, 0.0f);
                }
            }
            else
            {
                if (initialPos.y > finalPos.y)
                {
                    Charactor.transform.position += new Vector3(0.0f, 0.0f, -1.0f);
                }

                else
                {
                    Charactor.transform.position += new Vector3(0.0f, 0.0f, 1.0f);
                }
            }
        }
    }
}
