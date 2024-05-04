using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public Vector3 directionToMove;
    PlayerController controller;
    public float speed;
    BoxCollider destroyXValue;
    float xValue;
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller != null)
        {
            if (!controller.gameOver)
            {
                transform.Translate(directionToMove * Time.deltaTime * speed);

            }
            if(transform.position.x < -50)
            {
                Destroy(gameObject);
            }
           

            

        }
    }
}
