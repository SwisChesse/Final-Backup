using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDrag : MonoBehaviour
{
    private float startPosX;
    private float startPosY = 2;
    private bool isBeingHeld = false;


    private bool isNotDropped = false;

    private bool firstTurn = false;

    private float timer = 0f;

    public float addGrav = 1f;

    private Rigidbody2D rb;

    // Update is called once per frame

    //public GameObject dropper;

    ActivateGravity a;

    void start()
    {

        //TrialA(gameObject);

    }

    void TrialA(GameObject g)
    {
        Debug.Log("TI am getting this from");



    }

    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            Vector3 p = transform.position;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //if ((mousePos.x - startPosX) >= 3)

            //this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - 1, startPosY, 0);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, startPosY, 0);
        }
    }

    private void OnMouseDown()
    {
        if (firstTurn == false)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                //allows smooth movement when dragging the object and pevents object from snapping to different position
                //calculates the difference betweem center cords of object and the mouse pointer location
                startPosX = mousePos.x - this.transform.localPosition.x;
                //startPosY = mousePos.y - this.transform.localPosition.y;

                isBeingHeld = true;


            }
        }



    }

    private void OnMouseUp()
    {

        // rigidbody2D = GetComponent<Rigidbody2D>();
        isBeingHeld = false;
        firstTurn = true;

        Debug.Log("this is working");
        //rb.gravityScale += addGrav;
        //add rigidbody to allow the object to fall down after persons hand has risen off the touchpad.

        float yes = 1;
        // calls object from game with tac chores, and then gets component from scrip ActivateGravity.
        a = GameObject.FindGameObjectWithTag("dishwasher").GetComponent<ActivateGravity>();

        a.FallDown(yes);

    }



}
