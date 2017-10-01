using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
    private Animator animator = null;
    private AudioSource hitSound = null;

	// Use this for initialization
	void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        hitSound = gameObject.transform.parent.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    private void OnHit()
    {

        if (animator != null)
        {
            // start sound after half a second
            hitSound.PlayDelayed(.5f); 

            // play animation
            animator.Play("Hit");

            // move object
            gameObject.transform.parent.GetComponent<MoveObject>().MoveRandomly();
        }
    }
}
