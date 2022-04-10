using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera : MonoBehaviour
{

    public GameObject player;
	public Transform camTransform;
	public float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	private bool shaked=false;
	Vector3 originalPos;


	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
	}


    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
            shaked=true;
		}
		else if(shaked)
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
            shaked=false;
		}


                Vector3 interpolatedPosition = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z-12f);

        if(player&&shakeDuration <= 0)
        {
                transform.position = Vector3.Lerp(transform.position, interpolatedPosition, 3* Time.deltaTime);
		originalPos = camTransform.localPosition;
        }


    }
}
