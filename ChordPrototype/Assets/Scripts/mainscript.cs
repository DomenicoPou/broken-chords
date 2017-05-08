using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainscript : MonoBehaviour
{

    public WebCamTexture input;
    public Color[] data;
    public int blockw = 640 / 32;
    public int blockh = 480 / 32;

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
        
        data = new Color[blockw * blockh];
        int j = 0;
        int k = 0;
        List<int> avgColors = new List<int>();
        string midiout = "";
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
                avgColors.Add(averageColors(data));
                k++;
            } while (k*blockw < 640);
            j++;
        } while (j*blockh < 480);
        for (int i = 0; i < avgColors.Count; i++) {
            midiout = midiout + avgColors[i];
        }
        Debug.Log(midiout);
		createMidi(midiout);
    }

    //if white return 1 if black return 0   
    public int averageColors (Color[] colorblock)
    {
        //Should average all the colors here and then return the average as a color
        /**
        Random rnd = new Random();
        int output = rnd.Next(0, 3);
        if (output == 1)
        {
            return 1;
        }
        return 0;
        */
        //write the maths
        //average all the r's, then the g's, then the b's, and thats the average color
        float sumR = 0;
        float sumG = 0;
        float sumB = 0;

        for (int i = 0; i < colorblock.Length; i++){
            sumR += colorblock[i].r;
            sumG += colorblock[i].g;
            sumB += colorblock[i].b;
        }

        if ((sumR / colorblock.Length) + (sumG / colorblock.Length) + (sumB / colorblock.Length) >= 1.5)
        {
            return 1;
        }
        return 0;
    }

    /**  
     * M
     * 
     */

	//send midi notes at 
	public void createMidi(string data) {
        //if its a 1, throw the note at ableton
        int[,] noteArray = new int[blockw, blockh];
        //List<int[]> noteArray = new List<int[]>();
        for (int j = 0; j < blockw; j++)
        {
            for(int i = 0; i < blockh; i++)
            {
                noteArray[j, i] = data[i+j];
            }
        }

        //noteArray[0-blockw, 0] is the first note
        //noteArray[0-blockw, 1] is the second note
        //etc up to noteArray[0-blockw, blockh]


    }

}
