using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test004 : MonoBehaviour
{
    public int hp = 180;
    public Text hptext;
    public Text hpStatus;
    void Update()
    {
        hpStatus.text = hp.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            hp += 10;
        }
        if (Input.GetMouseButtonDown(1))
        {
            hp -= 10;
        }


            if (hp <= 50)
        {
            //Debug.Log("���� !!");
            hptext.text = "����!!";
        }
        else if (hp >= 200)
        {
            //Debug.Log("���� !!");
            hptext.text = "����!!";
        }
        else
        {
            //Debug.Log("���!!");
            hptext.text = "���!!";
        }
    }
}
