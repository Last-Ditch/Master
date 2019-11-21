using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoardChangeScipt : MonoBehaviour
{
    public Sprite[] boardSprites;
     ProgressTracker PT;
    AudioSource Board;
    private SpriteRenderer SR;

    private void Start()
    {
        Board = GetComponent<AudioSource>();
        SR = GetComponent<SpriteRenderer>();

        //dont destroy on load objects reset references whever the scene changes, use this to get around that
        PT = GameObject.FindGameObjectWithTag("Progress").GetComponent<ProgressTracker>();
    }

    public void Update()
    {



        if( PT.enteredSlicr == true)
        {
            Board.Play();
            SR.sprite = boardSprites[1];
            if (PT.modelPicked == true)
            {
                Board.Play();
                SR.sprite = boardSprites[2];
                if (PT.MatPicked == true && PT.LHPicked == true && PT.InfillPicked == true )
                {
                    Board.Play();
                    SR.sprite = boardSprites[3];
                    if (PT.sliced == true)
                    {
                        Board.Play();
                        SR.sprite = boardSprites[4];
                        if (PT.TpuPicked == true)
                        {
                            Board.Play();
                            SR.sprite = boardSprites[13];
                            if (PT.sdPickedUp == true)
                            {
                                Board.Play();
                                SR.sprite = boardSprites[14];
                                if (PT.sdIn == true)
                                {
                                    Board.Play();
                                    SR.sprite = boardSprites[15];
                                    if (PT.filamentPickedUp == true)
                                    {
                                        Board.Play();
                                        SR.sprite = boardSprites[16];
                                        if (PT.filamenttBackofPrinter == true)
                                        {
                                            Board.Play();
                                            SR.sprite = boardSprites[17];
                                            if (PT.bedGlued == true)
                                            {
                                                SR.sprite = boardSprites[18];
                                                Board.Play();
                                                if (PT.enterUltimakerMenu == true)
                                                {
                                                    SR.sprite = boardSprites[19];
                                                    Board.Play();
                                                    if (PT.insertFilament == true)
                                                    {
                                                        Board.Play();
                                                        SR.sprite = boardSprites[20];
                                                        if (PT.objectPrinting == true)
                                                        {
                                                            Board.Play();
                                                            SR.sprite = boardSprites[21];
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
                            Board.Play();
                            SR.sprite = boardSprites[5];
                            if (PT.sdPickedUp == true)
                            {
                                Board.Play();
                                SR.sprite = boardSprites[6];
                                if (PT.sdIn == true)
                                {
                                    Board.Play();
                                    SR.sprite = boardSprites[7];
                                    if (PT.filamentPickedUp == true)
                                    {
                                        Board.Play();
                                        SR.sprite = boardSprites[8];
                                        if (PT.filamenttBackofPrinter == true)
                                        {
                                            Board.Play();
                                            SR.sprite = boardSprites[9];
                                        
                                                if (PT.enterUltimakerMenu == true)
                                                {
                                                    SR.sprite = boardSprites[10];
                                                    Board.Play();
                                                    if (PT.insertFilament == true)
                                                    {
                                                        Board.Play();
                                                        SR.sprite = boardSprites[11];
                                                        if (PT.objectPrinting == true)
                                                        {
                                                            Board.Play();
                                                            SR.sprite = boardSprites[12];
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
}
