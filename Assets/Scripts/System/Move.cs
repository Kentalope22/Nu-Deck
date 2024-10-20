using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script by Rad
public class Move
{
    // Properties to be allow access of other files of these variables
    public MoveBase Base {get; set; }
    public int PP { get; set; }
    
    // Constructor of the Move
    public Move(MoveBase pBase)
    {
        Base = pBase;
        PP = pBase.PP;
    }

}
