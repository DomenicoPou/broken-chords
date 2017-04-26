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

    // FixedUpdate is called everye 20ms or so
    //the time can be changed in settings somewhere
    void FixedUpdate()
    {
        //Process this puppy

        //maxh=1080 by maxw=1920
        //Color[] color;
        //Debug.Log(input.GetPixel(100, 100));
        int blockw = 640 / 32;
        int blockh = 480 / 32;
        data = new Color[blockw * blockh];
        int j = 0;
        int k = 0;
        Color avgBlockColor;
        do
        {
            
            //data = input.GetPixels(j*blockw, k*blockh, blockw, blockh);
            //Debug.Log("the "+j+k+"th color is: " + data[0].ToString());
            Debug.Log("first row");
            k = 0;
            do
            {
                Debug.Log(k+"th column");
                Debug.Log(j + k +"th section");
                data = new Color[blockw * blockh];
                data = input.GetPixels(k * blockw, j * blockh, blockw, blockh);
                //this is the average color fro the block specified
                avgBlockColor = averageColors(data);
                k++;
            } while (k*blockw < 640);
            j++;
        } while (j*blockh < 480);
    }

    Color averageColors (Color[] colorblock)
    {
        //Should average all the colors here and then return the average as a color
        return colorblock[0];
    }

}
