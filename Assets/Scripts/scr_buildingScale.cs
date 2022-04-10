using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_buildingScale : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 origScale;
    void Start()
    {
        origScale=transform.localScale;
        transform.localScale=new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale=Vector3.Lerp(transform.localScale,origScale,1*Time.deltaTime);
    }
}
