using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectCollision : MonoBehaviour
{
    //find a way to make the object stop moving when it hits the corner, could change the startPosX to ------------------------------------------------------------------><><>><><><>><><><><><><>

    //remember to change collider to collider2D for 2D objects

    public Text scoreText;
    int score = 0;
    ObjectDragVacuum odv;
    float yes = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.gameObject);
    }

    void ProcessCollision(GameObject collider)
    {
        //if the gameobject this script is assigned to collides with object tagged "Border"
        if (collider.gameObject.CompareTag("Border"))
        {
            HittingBorder();
        }
        if (collider.gameObject.CompareTag("ground"))
        {
            Debug.Log("I made it");
            odv = GameObject.FindGameObjectWithTag("vacuum").GetComponent<ObjectDragVacuum>();
            Debug.Log("I made it in between");
            odv.appear(yes);
            AddPoint();

        }
        if (collider.gameObject.CompareTag("fallen"))
        {
            odv = GameObject.FindGameObjectWithTag("vacuum").GetComponent<ObjectDragVacuum>();
            Debug.Log("I fell");
            odv.appear(yes);
            MinusPoint();
        }

    }
    //method carried from collision
    void HittingBorder()
    {

        Debug.Log("You have hit left side");
    }

    //goes to ObjectDragVacuum script


    public void AddPoint()
    {
        Debug.Log("Add a point!!");
        score += 1;
        scoreText.text = score.ToString();
    }

    public void MinusPoint()
    {
        if (score > 0)
        {
            score -= 1;
            scoreText.text = score.ToString();
        }

    }
}
