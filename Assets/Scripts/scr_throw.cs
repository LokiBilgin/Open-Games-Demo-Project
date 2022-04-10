using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_throw : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf",5);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position= Vector3.Lerp(transform.position,target.position,1.5f*Time.deltaTime);
    }
}
