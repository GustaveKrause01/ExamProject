using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardMechanica : MonoBehaviour
{
   


    public int CurrentCard;
    public bool Begin;
    public float timeRemaining;
    public bool that;

    
    public GameObject[] G_cards;

    public Sprite[] S_Image;

    public List<int> IslandType = new List<int>();

    private int RandomNum;


    // Start is called before the first frame update
    void Start()
    {
        //This is to generate a random number and use that number to assign the images to their cards
        IslandType = new List<int>(new int[G_cards.Length]);

        for (int i = 0; i< G_cards.Length; i++)
        {
            RandomNum = UnityEngine.Random.Range(1, (S_Image.Length) + 1);
            while (IslandType.Contains(RandomNum))
            {
                RandomNum = UnityEngine.Random.Range(1, (S_Image.Length) + 1);
            }
            IslandType[i] = RandomNum;
            G_cards[i].GetComponent<SpriteRenderer>().sprite = S_Image[(IslandType[i] - 1)];
        }

        Begin = false;
        timeRemaining = 0.2F;
        that = false;
       
    }



    void Update()
    {
        //time before the cards start to flip
        if (timeRemaining > 0 && Begin == true && CurrentCard <= 8)
        {
            
            timeRemaining -= Time.deltaTime;

            that = false;
        }
        else if( timeRemaining < 0.15F)
        {
            
            CurrentCard += 1;
            that = true;
            Debug.Log("timer starts");
            timeRemaining = 0.2F;
           
        }
        

       
        
    }

    public void FirstTurn()
    {
        CurrentCard = 1;
        Begin = true;
        that = false;
    }

   
}
