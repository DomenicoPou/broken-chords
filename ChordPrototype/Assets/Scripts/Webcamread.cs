using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public WebCamTexture input;
    public Color[] data;

    // Use this for initialization
    void Start() {
        //read from the webcam
        WebCamDevice[] devices = WebCamTexture.devices;
        //for (int i = 0; i < devices.Length; i++)
        //{
        //    Debug.Log(devices[i].name);
        //}

        Debug.Log("abcdef");
        input = new WebCamTexture(devices[0].name);
        Debug.Log("nopq");
        input.Play();
        Debug.Log("the fi");
        //1080 by 1920
        Color[] color;
        data = new Color[32 * 32];
        color = input.GetPixels(0, 0, 32, 32);
        Debug.Log("the first color is: " + color[10].ToString()); 
	}
	
	// Update is called once per frame
	void Update () {
		//Process this puppy

	}
}
