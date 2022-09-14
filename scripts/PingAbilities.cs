using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PingAbilities : cardAbilities
{
    public override void OnCompile()
    {
        playerManager.CmdGMChangeVariables(1);
    }

    public override void OnExecute()
    {
        playerManager.CmdGMChangeBP(2,1);
    }
}
