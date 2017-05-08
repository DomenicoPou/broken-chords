using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class backupprototype : MonoBehaviour {

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

		input = new WebCamTexture(devices[0].name);
		input.Play();



	}


    /*
	[DLLImport("USER32.DLL", CharSet = CharSet.Unicode)]
	public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DLLImport("USER32")]
	public static extern bool SetForegroundWindow(IntPtr hWnd);
    */


	// FixedUpdate is called everye 20ms or so
	//the time can be changed in settings somewhere
	void FixedUpdate(){
		string _SavePath = "C:/WebcamSnaps/";
		//save the webcom texture as a png
		Texture2D snap = new Texture2D(input.width, input.height);
		snap.SetPixels(input.GetPixels ());
		snap.Apply();

		System.IO.File.WriteAllBytes (_SavePath + "sample.jpg", snap.EncodeToJPG ());
		Debug.Log("snapshot saved");
		//execute i2m with that png loaded
		Process i2sm = new Process();
		i2sm.StartInfo.FileName = _SavePath + "i2sm/image2midi.exe";
		i2sm.StartInfo.Arguments = _SavePath + "sample.png";
		i2sm.Start();

        Process script = new Process();
        script.StartInfo.FileName = _SavePath + "usei2sm.ps1";
        script.Start();

        /*
        IntPtr i2mHandle = FindWindow("WindowsForms10.Window.8.app.0.378734a", "i2sm");
        if (i2mHandle != IntPtr.Zero)
        {
            SetForegroundWindow(i2mHandle);
            //sent key strokes
            SendKeys.SendWait("%");
            SendKeys.SendWait("{DOWN 2}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait("s");
            SendKeys.SendWait("a");
            SendKeys.SendWait("m");
            SendKeys.SendWait("p");
            SendKeys.SendWait("l");
            SendKeys.SendWait("e");
            SendKeys.SendWait(".");
            SendKeys.SendWait("j");
            SendKeys.SendWait("p");
            SendKeys.SendWait("g");
            SendKeys.SendWait("{ENTER}");
            //WaitForSecondsRealtime (1);
            SendKeys.SendWait("{TAB 14}");
            SendKeys.SendWait("{ENTER}");
        }
        */

    }
}
