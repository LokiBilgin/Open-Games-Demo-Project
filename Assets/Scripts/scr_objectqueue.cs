using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_objectqueue : MonoBehaviour
{
    public List<Transform> objects = new List<Transform>();
    public int beginSize;
    public GameObject TheObject;
    public Transform WillBeDestroyed;
    public scr_Controller cntrlr;
    void Start()
    {
        for (int i = 0; i < beginSize - 1; i++)
        {
            if(i<beginSize)
            {
                AddBodyPart();
            }
        }
    }

    public void Desired()
        {
            int a= objects.Count-1;
            for (int i = 0; i < objects.Count; i++)
            {
                if(objects[i]!=null)
                objects[i].gameObject.GetComponent<scr_objectdesired>().DesiredPosition= new Vector3(transform.position.x, transform.position.y+a/4f, transform.position.z);
                a--;
            }
        }


    public void AddBodyPart()
        {
            Transform newpart = (Instantiate (TheObject, objects[objects.Count - 1].position, objects[objects.Count - 1].rotation) as GameObject).transform;
            newpart.transform.position =  cntrlr.target.position;
            newpart.SetParent(transform);
            objects.Add(newpart);
        }

    public void Dest()
    {
        WillBeDestroyed=objects[objects.Count - 1];
    }
    // Update is called once per frame
    void Update()
    {
                if (Input.GetKeyDown("space"))
                {
                    AddBodyPart();
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if(objects[objects.Count - 1].gameObject)
                    {
                        WillBeDestroyed=objects[objects.Count - 1];
                    }
                }


        Desired();
        if(WillBeDestroyed!=null)
        {
            RemoveBodyPart();
        }
    }

    public void RemoveBodyPart()
    {
        if(!WillBeDestroyed.gameObject.GetComponent<scr_objectdesired>().immortal)
        {
            Destroy(WillBeDestroyed.gameObject);
            objects.RemoveAt(objects.Count-1);  
                if(objects.Count == 0)
                {
                    //    Destroy(gameObject);
                }
        }
    }

}
