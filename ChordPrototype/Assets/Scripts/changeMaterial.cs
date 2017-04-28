using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMaterial : MonoBehaviour {
    public RawImage rawimage;
	// Use this for initialization
	void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }
        // assuming the first available WebCam is desired
        WebCamTexture tex = new WebCamTexture(devices[0].name);
        rawimage.texture = tex;
        rawimage.material.mainTexture = tex;
        tex.Play();
    }
}
