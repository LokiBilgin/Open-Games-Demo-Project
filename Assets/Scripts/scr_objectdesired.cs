using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_objectdesired : MonoBehaviour
{
    public Vector3 DesiredPosition;
    public float speed;
    public bool immortal=false;
    void Start()
    {
//speed=0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, DesiredPosition, step);
    }
}
