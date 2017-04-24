using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainscript : MonoBehaviour
{

    public WebCamTexture input;
    public Color[] data;

    // Use this for initialization
    void Start()
    {
        //read from the webcam
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }

        Debug.Log("abcdef");
        input = new WebCamTexture(devices[0].name);
        Debug.Log("nopq");
        input.Play();

        Debug.Log("the fi");


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Process this puppy

        //1080 by 1920
        //Color[] color;
        //Debug.Log(input.GetPixel(100, 100));

        data = new Color[1 * 1];
        data = input.GetPixels(100, 100, 1, 1);
        Debug.Log("the first color is: " + data[0].ToString());
    }
}
