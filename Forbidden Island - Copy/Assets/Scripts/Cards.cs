using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    public int TurnNumber;
    float lerpDuration = 0.3f;
    bool rotating;

    public int CardNum;

    public BoardMechanica Board;

    public SpriteRenderer IslandTile;


    private void Start()
    {
        //spriteRenderer.sprite = newSprite;
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !rotating )
        //{
        //    StartCoroutine(Rotate90());
        //}

        if (CardNum == Board.CurrentCard && Board.that == true)
        {
            Spin();
        }
    }
    IEnumerator Rotate90()
    //This rotates the cards
    {

        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 180, 0);
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        rotating = false;
        //Board.CurrentCard += 1;
    }

    public void Spin()
    {
        StartCoroutine(Rotate90());
    }
   
    
}
