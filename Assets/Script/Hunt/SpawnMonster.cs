using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    private const string EnemyPrePath = "Prefabs/Monster";
    private Vector2 XRange = new Vector2(-2.5f,1.2f);
    private Vector2 YRange = new Vector2(-1.8f,2.2f);

    public void Start() 
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }
    public void Spawn() 
    {
        float PosX = Random.Range(XRange.x, XRange.y);
        float PosY = Random.Range(YRange.x, YRange.y);
        GameObject monster = Instantiate(Resources.Load(EnemyPrePath), transform) as GameObject;
        monster.transform.localPosition += new Vector3(PosX, PosY, 0);
    }
}
