using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_particle : MonoBehaviour
{
    public ParticleSystem particle;
    public float scaleYorig;
    public string kind;
    public scr_objectqueue stack;
    // Start is called before the first frame update
    void Start()
    {
        scaleYorig=transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale=Vector3.Slerp(transform.localScale,new Vector3(transform.localScale.x,scaleYorig,transform.localScale.z),2*Time.deltaTime);
    }
}
