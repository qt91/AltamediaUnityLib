using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Settings
{
    public bool WindowsReadTime = true;//State ReadTime if equal "true" auto loop reload follow ReadTimeLoop
    public float WindowsReadTimeLoop = 1f;//Time loop reload setting file
    public int WindowsPositionX = -5;//Postion X Left to Right
    public int WindowsPositionY = -25;//Postion Y Top to Down
    public int WindowsScaleX = 1;//Scale show window
    public int WindowsScaleY = 1;//Scale show window

    public void Load()
    {
        AltaGlobal.Settings = AltaStatic.Read<Settings>("Settings.xml");
    }

    public void Save()
    {
        AltaStatic.Write<Settings>(this, "Settings.xml");
    }


}
