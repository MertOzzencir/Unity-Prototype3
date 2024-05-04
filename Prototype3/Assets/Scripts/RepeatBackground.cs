using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    BoxCollider BoxCollider;
    Vector3 startPos;

    float halfSizeOfObject;
    private void Start()
    {
        startPos = transform.position;
        BoxCollider = GetComponent<BoxCollider>();
        halfSizeOfObject = BoxCollider.size.x / 2;
    }
    void Update()
    {
        if(transform.position.x < startPos.x - halfSizeOfObject)
        {
            transform.position = new Vector3(startPos.x,transform.position.y,transform.position.z);

        }
    }
}
