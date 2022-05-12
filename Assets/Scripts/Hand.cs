using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    SkinnedMeshRenderer Mesh;
    public float speed;
    private float gripTarget;
    private float triggerTarget;
    private float gripCur;
    private float triggerCur;
    private string animatorGripPar = "Grip";
    private string animatorTrigPar = "Trigger";

    void Start()
    {
        animator = GetComponent<Animator>();   
        Mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();   
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand() {


        if (gripCur != gripTarget) { 
            gripCur = Mathf.MoveTowards(gripCur, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripPar, gripCur);
        }
        if (triggerCur != triggerTarget)
        {
            triggerCur = Mathf.MoveTowards(triggerCur, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTrigPar, triggerCur);
        }
    }
    public void tgVisible()
    {
        Mesh.enabled = !Mesh.enabled;
    }
}
