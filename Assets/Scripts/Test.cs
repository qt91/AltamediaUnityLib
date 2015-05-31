using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Test : MonoBehaviour {

	// Use this for initialization
    public Text Msg;
	void Start () {
        //AltaGlobal.Settings.AppName = "Quang Thinh";
        //AltaGlobal.Settings.Save();
        AltaGlobal.Settings.Load();
	}
	
	// Update is called once per frame
	void Update () {

	}

}




