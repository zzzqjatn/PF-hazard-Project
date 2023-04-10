using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public KeyNumber KeyInput_R()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return KeyNumber.UpArrow;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return KeyNumber.DownArrow;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return KeyNumber.LeftArrow;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return KeyNumber.RightArrow;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            return KeyNumber.None;
        }
        
        return KeyNumber.None;
    }
}

public enum KeyNumber
{
    None, UpArrow, DownArrow, LeftArrow, RightArrow
}