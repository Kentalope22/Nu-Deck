using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase baseStats {get; set; }
    public int PP { get; set; }
    public Move(MoveBase pBase)
    {
        baseStats = pBase;
        PP = pBase.PP;
    }

}