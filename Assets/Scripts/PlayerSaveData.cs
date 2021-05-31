using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public  class PlayerSaveData
{
    public  bool[] chapters = new bool[] {true,true, true, true, true, true, true, true, true, true, true, true, true, true, true };
    public  bool AllClearBool = false;
    public int Choice;
    public int GameProgress;
    public int SoulAmount;
    public string PlayerLogOutTimeString;
}
