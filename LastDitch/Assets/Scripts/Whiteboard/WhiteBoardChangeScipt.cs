using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoardChangeScipt : MonoBehaviour
{
    int counter = 0;
    public Sprite[] boardSprites;
     ProgressTracker PT;
    AudioSource Board;
    private SpriteRenderer SR;

    private void Start()
    {
        Board = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();
        counter = 0;
        //dont destroy on load objects reset references whever the scene changes, use this to get around that
        PT = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }

    public void Update()
    {

        //Debug.Log();

        if( PT.enteredSlicr == true)
        {
            ChangeBoard(1);
            //SR.sprite = boardSprites[1];
            if (PT.modelPicked == true)
            {
                ChangeBoard(2);
                //Board.Play();
                //SR.sprite = boardSprites[2];
                if (PT.MatPicked == true && PT.LHPicked == true && PT.InfillPicked == true )
                {
                    ChangeBoard(3);
                    //Board.Play();
                    //SR.sprite = boardSprites[3];
                    if (PT.sliced == true)
                    {
                        ChangeBoard(4);
                        //Board.Play();
                        //SR.sprite = boardSprites[4];
                        if (PT.TpuPicked == true)
                        {
                            ChangeBoard(13);
                            //Board.Play();
                            //SR.sprite = boardSprites[13];
                            if (PT.sdPickedUp == true)
                            {
                                ChangeBoard(14);
                                //Board.Play();
                                //SR.sprite = boardSprites[14];
                                if (PT.sdIn == true)
                                {
                                    ChangeBoard(15);
                                    //Board.Play();
                                    //SR.sprite = boardSprites[15];
                                    if (PT.filamentPickedUp == true)
                                    {
                                        ChangeBoard(16);
                                        //Board.Play();
                                        //SR.sprite = boardSprites[16];
                                        if (PT.filamenttBackofPrinter == true)
                                        {
                                            ChangeBoard(17);
                                            //Board.Play();
                                            //SR.sprite = boardSprites[17];
                                            if (PT.bedGlued == true)
                                            {
                                                ChangeBoard(18);
                                                //SR.sprite = boardSprites[18];
                                                //Board.Play();
                                                if (PT.enterUltimakerMenu == true)
                                                {
                                                    ChangeBoard(19);
                                                    //SR.sprite = boardSprites[19];
                                                    //Board.Play();
                                                    if (PT.insertFilament == true)
                                                    {
                                                        ChangeBoard(20);
                                                        //Board.Play();
                                                        //SR.sprite = boardSprites[20];
                                                        if (PT.objectPrinting == true)
                                                        {
                                                            ChangeBoard(21);
                                                            //Board.Play();
                                                            //SR.sprite = boardSprites[21];
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            ChangeBoard(5);
                            //Board.Play();
                            //SR.sprite = boardSprites[5];
                            if (PT.sdPickedUp == true)
                            {
                                ChangeBoard(6);
                                //Board.Play();
                                //SR.sprite = boardSprites[6];
                                if (PT.sdIn == true)
                                {
                                    ChangeBoard(7);
                                    //Board.Play();
                                    //SR.sprite = boardSprites[7];
                                    if (PT.filamentPickedUp == true)
                                    {
                                        ChangeBoard(8);
                                        //Board.Play();
                                        //SR.sprite = boardSprites[8];
                                        if (PT.filamenttBackofPrinter == true)
                                        {
                                            ChangeBoard(9);
                                            //Board.Play();
                                            //SR.sprite = boardSprites[9];

                                            if (PT.enterUltimakerMenu == true)
                                                {
                                                ChangeBoard(10);
                                                //SR.sprite = boardSprites[10];
                                                //Board.Play();
                                                if (PT.insertFilament == true)
                                                    {
                                                    ChangeBoard(11);
                                                    //Board.Play();
                                                    //SR.sprite = boardSprites[11];
                                                    if (PT.objectPrinting == true)
                                                        {
                                                        ChangeBoard(12);
                                                        //Board.Play();
                                                        //SR.sprite = boardSprites[12];
                                                    }
                                                }
                                                }
                                            
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }
    }


    void ChangeBoard(int index)
    {
        Debug.Log(1);
        while(counter < index)
        {
            Board.Stop();
            Board.Play();
            Debug.Log(2);
            SR.sprite = boardSprites[index];
            counter++;
        }
    }
}
