using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    // Independent data of Moves
    public MoveBase baseStats {get; set; }
    public int PP { get; set; }
    // Grabs the PP and stats of the Move based off the its base
    public Move(MoveBase pBase)
    {
        baseStats = pBase;
        PP = pBase.PP;
    }

}