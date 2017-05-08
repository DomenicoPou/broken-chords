add-type -AssemblyName microsoft.VisualBasic

add-type -AssemblyName System.Windows.Forms

start-sleep -Milliseconds 500

[Microsoft.VisualBasic.Interaction]::AppActivate(“i2sm”)

[System.Windows.Forms.SendKeys]::SendWait(“”)

[System.Windows.Forms.SendKeys]::SendWait("%");
[System.Windows.Forms.SendKeys]::SendWait("{DOWN 2}");
[System.Windows.Forms.SendKeys]::SendWait("{RIGHT}");
[System.Windows.Forms.SendKeys]::SendWait("{DOWN}");
[System.Windows.Forms.SendKeys]::SendWait("{ENTER}");
Sleep 1;
[System.Windows.Forms.SendKeys]::SendWait("s");
[System.Windows.Forms.SendKeys]::SendWait("a");
[System.Windows.Forms.SendKeys]::SendWait("m");
[System.Windows.Forms.SendKeys]::SendWait("p");
[System.Windows.Forms.SendKeys]::SendWait("l");
[System.Windows.Forms.SendKeys]::SendWait("e");
[System.Windows.Forms.SendKeys]::SendWait(".");
[System.Windows.Forms.SendKeys]::SendWait("j");
[System.Windows.Forms.SendKeys]::SendWait("p");
[System.Windows.Forms.SendKeys]::SendWait("g");
[System.Windows.Forms.SendKeys]::SendWait("{ENTER}");
Sleep 3;

Sleep 0.5;
[System.Windows.Forms.SendKeys]::SendKeys.SendWait("{ENTER}");