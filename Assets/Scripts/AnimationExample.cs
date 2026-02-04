using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{
    public Animation animationn;
    public AnimationClip run;
    public AnimationClip idle;
   
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
           PlayAnimation(run);
        }

        else if (Input.GetKeyDown(KeyCode.X))
        {
           PlayAnimation(idle);
        }
    }
    private void PlayAnimation(AnimationClip c)
    {
        //animationn.clip = c;
       animationn.CrossFade(c.name);
    }
}
