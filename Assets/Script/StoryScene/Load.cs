using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    private const string BGPrepath = "Prefabs/BG";

    void Start()
    {
        GameObject BG = Instantiate(Resources.Load(BGPrepath)) as GameObject;
    }
}
