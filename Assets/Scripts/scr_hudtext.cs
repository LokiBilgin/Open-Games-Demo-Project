using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_hudtext : MonoBehaviour
{
    public TextMeshPro txt;
    private float originalY;

    // Start is called before the first frame update
    void Start()
    {
        originalY=transform.eulerAngles.y;
    }
    void Update()
    {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,new Vector3(transform.eulerAngles.x,originalY,transform.eulerAngles.z),8*Time.deltaTime);
    }
}
