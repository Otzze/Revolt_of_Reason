using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Controller_State : MonoBehaviour
{
    private Animator _animator;
    private int _IsWalkingHash;
    private int _IsLookingHash;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        Debug.Log(_animator);

        _IsWalkingHash = Animator.StringToHash("IsWalking");
        _IsLookingHash = Animator.StringToHash("IsLooking");

    }

    // Update is called once per frame
    void Update()
    {
        bool IsLooking = _animator.GetBool(_IsLookingHash);
        bool IsWalking = _animator.GetBool(_IsWalkingHash);
        bool fowardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift"); // a revoir
        
        
        // if player presses w key
        if (!IsWalking && fowardPressed)
        {
            // then set the IsWalking boolean to be true
            _animator.SetBool(_IsWalkingHash,true);
        }
        // a revoir 
        if (IsWalking && !fowardPressed)
        {
            _animator.SetBool(_IsWalkingHash,false);
        }
        // if player is walking and presses left shift
        if (!IsLooking && (fowardPressed && runPressed))
        {
            // then set the isRunning boolean to be true
            _animator.SetBool(-_IsLookingHash,true);
        }
        // if player stops running or stops walking
        if (IsLooking && (!fowardPressed || !runPressed))
        {
            _animator.SetBool(-_IsLookingHash,false);
        }
    }
}
