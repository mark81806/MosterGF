using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CharactorMove : MonoBehaviour
{
    public Animator a;
    public Transform Head;
    public Transform Hair;
    public Transform Scarf;
    public Transform Face;
    //public Animator test;
    public void ClickToMove() 
    {
        Sequence Move = DOTween.Sequence();
        float moveTime = 1.4f;
        Vector3 movePos =new Vector3( 11.69f, 10.94f,11.31f); //hair,face head 0.05
        Vector3 movePos2 =new Vector3(11.74236f, 10.995f, 11.36f);
        Move.Append(Head.DOLocalMoveY(movePos.z, moveTime)).
            Insert(0, Hair.DOLocalMoveY(movePos.x, moveTime)).Insert(0, Face.DOLocalMoveY(movePos.y, moveTime));
        Move.Append(Head.DOLocalMoveY(movePos2.z, moveTime)).Insert(moveTime, Hair.DOLocalMoveY(movePos2.x, moveTime)).
             Insert(moveTime, Face.DOLocalMoveY(movePos2.y, moveTime));
        Move.SetLoops(200);
        a.enabled = true;
    }


}
