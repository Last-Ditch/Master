﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public GameObject text;
    public GameObject hoop;
    public GameObject player;
    private AudioSource sound;
    public AudioClip cheer;

    private void Start()
    {
        anim1 = text.GetComponent<Animator>();
        anim2 = hoop.GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.IsChildOf(player.transform))
        {
            return;
        }
        else
        {
            if (other.gameObject.tag != "Player")
            {
                anim1.SetTrigger("net");
                anim2.SetTrigger("net");
                sound.PlayOneShot(cheer);

                
            }
        }
    }
}
