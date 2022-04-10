using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class scr_Controller : MonoBehaviour {
 
    public float speed = 10.0f;
    public float rotation = 360f;
    public float gravity;
    public float jump = 7f;
    public bool alive=true;
 	public VariableJoystick variableJoystick;
    
    private float groundDistance;
    float dr = 0f;
	public Animator anim;
    public Vector3 v3;
    private Vector3 movement;
    public bool weco=true;
    private bool runrun=false;
    private GameObject theOther;
    public Vector3 pos;
    private bool fought=false;
    public Transform target;
    public Transform playerModel;
    public bool looking=true;
    public ParticleSystem damageparticle;
    public scr_camera cam;

    public int wood;
    public int gold;
    public int rock;
    
    public scr_objectqueue woodStack;
    public scr_objectqueue goldStack;
    public scr_objectqueue rockStack;

    public GameObject throwWood;
    public GameObject throwGold;
    public GameObject throwRock;

    void throws()
    {
        if(target.gameObject.GetComponent<scr_place>().woodNeed>0&&wood>0)
        {
            target.gameObject.GetComponent<scr_place>().woodNeed--;
            if(target.gameObject.GetComponent<scr_place>().woodHud)
            target.gameObject.GetComponent<scr_place>().woodHud.transform.eulerAngles=new Vector3(target.gameObject.GetComponent<scr_place>().woodHud.transform.eulerAngles.x,-0.17f,target.gameObject.GetComponent<scr_place>().woodHud.transform.eulerAngles.z);
            GameObject throwobj= Instantiate(throwWood,transform.position,Quaternion.identity);
            throwobj.GetComponent<scr_throw>().target=target;
            woodStack.Dest();
            wood--;
        }
        if(target.gameObject.GetComponent<scr_place>().goldNeed>0&&gold>0)
        {
            target.gameObject.GetComponent<scr_place>().goldNeed--;
            if(target.gameObject.GetComponent<scr_place>().woodHud)
            target.gameObject.GetComponent<scr_place>().goldHud.transform.eulerAngles=new Vector3(target.gameObject.GetComponent<scr_place>().goldHud.transform.eulerAngles.x,-0.17f,target.gameObject.GetComponent<scr_place>().goldHud.transform.eulerAngles.z);
            GameObject throwobj= Instantiate(throwGold,transform.position,Quaternion.identity);
            throwobj.GetComponent<scr_throw>().target=target;
            goldStack.Dest();
            gold--;
        }
        if(target.gameObject.GetComponent<scr_place>().rockNeed>0&&rock>0)
        {
            target.gameObject.GetComponent<scr_place>().rockNeed--;
            if(target.gameObject.GetComponent<scr_place>().woodHud)
            target.gameObject.GetComponent<scr_place>().rockHud.transform.eulerAngles=new Vector3(target.gameObject.GetComponent<scr_place>().rockHud.transform.eulerAngles.x,-0.17f,target.gameObject.GetComponent<scr_place>().rockHud.transform.eulerAngles.z);
            GameObject throwobj= Instantiate(throwRock,transform.position,Quaternion.identity);
            throwobj.GetComponent<scr_throw>().target=target;
            rockStack.Dest();
            rock--;
        }

    }

    // Use this for initialization
 void canrun()
    {
        runrun=true;
    }

    void Start () 
	{
		anim =GetComponent<Animator>();
    }
    
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="collectable")
        {
            looking=false;
            anim.SetBool("attack",true);
            target=other.gameObject.transform;
        }
        if(other.gameObject.tag=="place")
        {
            if((other.gameObject.GetComponent<scr_place>().woodNeed>0&&wood>0)||(other.gameObject.GetComponent<scr_place>().goldNeed>0&&gold>0)||(other.gameObject.GetComponent<scr_place>().rockNeed>0&&rock>0))
            {
                looking=false;
                anim.SetBool("throw",true);
                target=other.gameObject.transform;
            }
            else
            {
                anim.SetBool("throw",false);
                looking=true;
            }
        }
        if(other.gameObject.tag=="trash")
        {
            if((wood>0)||(gold>0)||(rock>0))
            {
                looking=false;
                anim.SetBool("throw",true);
                target=other.gameObject.transform;
            }
            else
            {
                anim.SetBool("throw",false);
                looking=true;
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="collectable")
        {
            anim.SetBool("attack",false);
            looking=true;
        }
        if(other.gameObject.tag=="place")
        {
            anim.SetBool("throw",false);
            looking=true;
        }

    }
    void MakeAttack()
    {
        if(target.gameObject.GetComponent<scr_particle>().kind=="wood")
        {
            wood++;
            target.gameObject.GetComponent<scr_particle>().stack.AddBodyPart();
        }
        if(target.gameObject.GetComponent<scr_particle>().kind=="gold")
        {
            gold++;
            target.gameObject.GetComponent<scr_particle>().stack.AddBodyPart();

        }
        if(target.gameObject.GetComponent<scr_particle>().kind=="rock")
        {
            rock++;
            target.gameObject.GetComponent<scr_particle>().stack.AddBodyPart();
        }

        damageparticle.Play();
        target.gameObject.GetComponent<scr_particle>().particle.Play();
target.transform.localScale=new Vector3(target.transform.localScale.x,target.transform.localScale.y/1.2f,target.transform.localScale.z);
        cam.shakeDuration=0.3f;
    }
    void Update () 
	{
        if(variableJoystick.released)
        {
			anim.SetBool("walk",false);
        }

        float moveFB = variableJoystick.Vertical * speed;
        float moveLR = variableJoystick.Horizontal * speed;

            if((moveLR!=0||moveFB!=0)&&alive)
            {
                transform.parent=null;
                
                if(!anim.GetCurrentAnimatorStateInfo(0).IsName("TwoHanded")&&!anim.GetCurrentAnimatorStateInfo(0).IsName("smash")&&!anim.GetCurrentAnimatorStateInfo(0).IsName("Picking Up Object")&&!anim.GetCurrentAnimatorStateInfo(0).IsName("Cheer"))
                {

                    transform.position += transform.forward * Time.deltaTime * speed;
                    if(!anim.GetCurrentAnimatorStateInfo(0).IsName("walk"))
				        anim.SetBool("walk",true);
                }

            }

        if (moveLR != 0) 
		{
			dr = 90 * moveLR;
            fought=false;
			anim.SetBool("walk",true);
		}
		else
		{


		}
            
            if (moveFB < 0) dr = 180;
            if (moveFB > 0) dr = 0;

        pos=transform.position;

        /*
        if(transform.position.x>116.8143f)
        {
            transform.position= new Vector3(116.8143f,transform.position.y,transform.position.z);
        }
        if(transform.position.x<111.6865f)
        {
            transform.position= new Vector3(111.6865f,transform.position.y,transform.position.z);
        }
        */
        transform.position= new Vector3(transform.position.x,transform.position.y,transform.position.z);

        if (weco)
        {
            Vector3 newPos = new Vector3(variableJoystick.Horizontal , 0, variableJoystick.Vertical);
            var currentPos = transform.position;
		    var facePos = currentPos + newPos;
            transform.LookAt(facePos);
        }
        if(!looking)
        {
            Vector3 newPos1 = new Vector3(target.position.x , 0, target.position.z);
           playerModel.transform.LookAt(newPos1);
        }
        else
        playerModel.transform.eulerAngles=transform.eulerAngles;
    }
     
   
}