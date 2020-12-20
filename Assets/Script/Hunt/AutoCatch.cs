using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AutoCatch : MonoBehaviour
{

    public static AutoCatch self;
    public void Awake() 
    {
        self = this;
    }
    public bool autocatch = false;
    public void click() 
    {
        autocatch = true;
        Invoke("autocatchoff", 5f);
    }
    public void autocatchoff()
    {
        autocatch = false;
    }
}
