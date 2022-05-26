using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenter : MonoBehaviour
{
    Vector3 main = new Vector3();
    Vector3 l1 = new Vector3(-30f, 0f, 40f);
    Vector3 l2 = new Vector3(0f, 0f, 45f);
    Vector3 l3 = new Vector3(-23f, 0f, 40f);


    public void cenMain() 
    {
        this.transform.position = main; 
    }

    public void lev1() 
    {
        this.transform.position = l1;
    }
    public void lev2()
    {
        this.transform.position = l2;
    }
    public void lev3()
    {
        this.transform.position = l3;
    }
}
