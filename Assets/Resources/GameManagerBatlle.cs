using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBatlle : MonoBehaviour
{

    public enum E_StateEnum
    {
        PAUSE,
        MENU,
        COMBAT
    }

    public E_StateEnum state = E_StateEnum.MENU;

    // Use this for initialization
    void Start () {
		
	}
	

	// Update is called once per frame
	void Update ()
    {


	}
}
