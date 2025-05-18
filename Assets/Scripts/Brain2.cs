using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain2 
{
    public Player _player;
    private const int _constZero=0;
    private const int _constOne = 1;
    public Panelsmanasha _panelManasha;
    float _lOr;
    public void ListenKeys()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && _panelManasha._canStep)
        {
            _player.Step(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)&& _panelManasha._canStep)
        {
            _player.Step(true);
        }
   
        if(Input.GetKeyDown(KeyCode.A) && _panelManasha._canLateral || Input.GetKey(KeyCode.A) && _panelManasha._canLateral)
            _player.LeftAndRightMovment(-_constOne);
        if (Input.GetKeyDown(KeyCode.D) && _panelManasha._canLateral || Input.GetKey(KeyCode.D) && _panelManasha._canLateral)
            _player.LeftAndRightMovment(_constOne);
        if (Input.GetKeyUp(KeyCode.A) && _panelManasha._canLateral || Input.GetKeyUp(KeyCode.D) && _panelManasha._canLateral)
            _player.LeftAndRightMovment(_constZero);
        if (Input.GetKeyDown(KeyCode.S) && _panelManasha._canAgacharse || Input.GetKeyDown(KeyCode.LeftControl) && _panelManasha._canAgacharse || Input.GetKeyDown(KeyCode.RightControl) && _panelManasha._canAgacharse || Input.GetKeyDown(KeyCode.LeftShift) && _panelManasha._canAgacharse || Input.GetKeyDown(KeyCode.RightShift) && _panelManasha._canAgacharse)
            _player.Slide();
        if (Input.GetKeyDown(KeyCode.W)&& _panelManasha._canJump || Input.GetKeyDown(KeyCode.Space) && _panelManasha._canJump)
            _player.Jump();
      
    }
}
