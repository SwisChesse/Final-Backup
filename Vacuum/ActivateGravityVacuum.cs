using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravityVacuum : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject gb2d;

    float gravity = 1f;



    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;        
    }

    //yes represents if called by other script.
    public void FallDown(float yes)
    {
        if (yes == 1)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1;
            yes = 1;

        }
    }
}
