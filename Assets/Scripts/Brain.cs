using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain 
{
    public Player _player;
    private const int _constZero=0;
    private const int _constOne = 1;

    float _lOr;
    public void ListenKeys()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _player.Step(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _player.Step(true);
        }
   
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKey(KeyCode.A))
            _player.LeftAndRightMovment(-_constOne);
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            _player.LeftAndRightMovment(_constOne);
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            _player.LeftAndRightMovment(_constZero);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            _player.Slide();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            _player.Jump();
        if (Input.GetKey(KeyCode.UpArrow))
            _player.FireWalk();
        if (Input.GetKeyUp(KeyCode.UpArrow))
            _player._fireWalking = false;
    }
}
