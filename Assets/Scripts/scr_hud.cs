using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_hud : MonoBehaviour
{
    public scr_Controller player;
    public string kind;
    private Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kind=="wood")
        txt.text=player.wood.ToString();

        if(kind=="gold")
        txt.text=player.gold.ToString();

        if(kind=="rock")
        txt.text=player.rock.ToString();

    }
}
