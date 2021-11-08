using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollisionVacuum : MonoBehaviour
{
    //find a way to make the object stop moving when it hits the corner, could change the startPosX to ------------------------------------------------------------------><><>><><><>><><><><><><>

    //remember to change collider to collider2D for 2D objects

    ObjectDragVacuum odv;
    SaveProgress sva;
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
            Debug.Log("Minus a point");

            HittingBorder();
        }
        if (collider.gameObject.CompareTag("ground"))
        {

            odv = GameObject.FindGameObjectWithTag("vacuum").GetComponent<ObjectDragVacuum>();
            odv.appear(yes);
            AddPoint();
        }
        if (collider.gameObject.CompareTag("fallen"))
        {
            Debug.Log("Minus a point!!");
            MinusPoint();
            odv = GameObject.FindGameObjectWithTag("vacuum").GetComponent<ObjectDragVacuum>();
        }
    }
    //method carried from collision
    void HittingBorder()
    {
        Debug.Log("You have hit left side");
    }

    public Text scoreText;
    int score = 0;
    public void AddPoint()
    {
        Debug.Log("Add a point!!");
        score += 1;
        totalScore();


    }

    public void MinusPoint()
    {
        if (score > 0)
        {
            score -= 1;
            totalScore();
        }

    }

    public void totalScore()
    {
        scoreText.text = score.ToString();
        sva = GameObject.FindGameObjectWithTag("score").GetComponent<SaveProgress>();
       // sva.SaveScore(score.ToString);
    }
}
