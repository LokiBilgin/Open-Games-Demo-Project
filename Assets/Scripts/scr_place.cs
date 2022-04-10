using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_place : MonoBehaviour
{
    public int woodNeed;
    public int goldNeed;
    public int rockNeed;
    public InGameUI canvas;
    public int woodNeed2;
    public int goldNeed2;
    public int rockNeed2;
    public GameObject woodHud;
    public GameObject goldHud;
    public GameObject rockHud;
    public string kind;
    private bool done=false;
    public GameObject building;
    public scr_Controller cntrl;
    public float zz;
    public string soldierkind;
    public GameObject[] soldiers;

    void Start()
    {
        woodNeed2=woodNeed;
        goldNeed2=goldNeed;
        rockNeed2=rockNeed;
    }
    void MakeBuilding()
    {
        cntrl.anim.SetBool("throw",false);
        cntrl.looking=true;
        building.SetActive(true);
        gameObject.SetActive(false);
    }
    void MakeSoldier()
    {
        GameObject soldier= Instantiate(building, new Vector3(transform.position.x+zz,0,transform.position.z-3),Quaternion.identity);
        soldier.transform.eulerAngles=new Vector3(0,180,0);
        zz++;
        woodNeed=woodNeed2;
        goldNeed=goldNeed2;
        rockNeed=rockNeed2;

        if(rockNeed>0)
        rockHud.SetActive(true);

        if(goldNeed>0)
        goldHud.SetActive(true);

        if(woodNeed>0)
        woodHud.SetActive(true);

        done=false;

        if(soldierkind=="archer")
        {
            soldiers = GameObject.FindGameObjectsWithTag("archer");
            canvas.archer++;
        }
        if(soldierkind=="paladin")
        {
            soldiers = GameObject.FindGameObjectsWithTag("paladin");
            canvas.paladin++;
        }
        foreach (GameObject soldiero in soldiers)
        {
            soldiero.GetComponent<Animator>().SetTrigger("cheer");
        }

    }
    void Update()
    {
        if(woodHud)
        {
        if(woodNeed>0)
        {
            woodHud.GetComponent<scr_hudtext>().txt.text=woodNeed.ToString();
        }
        else
        {
            woodHud.SetActive(false);
        }
        if(goldNeed>0)
        {
            goldHud.GetComponent<scr_hudtext>().txt.text=goldNeed.ToString();
        }
        else
        {
            goldHud.SetActive(false);
        }
        if(rockNeed>0)
        {
            rockHud.GetComponent<scr_hudtext>().txt.text=rockNeed.ToString();
        }
        else
        {
            rockHud.SetActive(false);
        }
        }
        if(woodNeed<=0&&goldNeed<=0&&rockNeed<=0&&!done)
        {
            done=true;
            if(kind=="place")
            {
                MakeBuilding();
            }
            if(kind=="building")
            {
                MakeSoldier();
            }
        }

    }
}
