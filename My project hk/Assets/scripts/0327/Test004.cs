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
            //Debug.Log("도망 !!");
            hptext.text = "도망!!";
        }
        else if (hp >= 200)
        {
            //Debug.Log("공격 !!");
            hptext.text = "공격!!";
        }
        else
        {
            //Debug.Log("방어!!");
            hptext.text = "방어!!";
        }
    }
}
