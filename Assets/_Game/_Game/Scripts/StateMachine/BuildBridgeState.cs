using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridgeState : IState
{
    public void OnEnter(Bot bot)
    {
        //set des finish point;
        bot.SetDestinationFinishPoint();
    }

    public void OnExecute(Bot bot)
    {
        //check het gach 
        //+ change state seek brick
        //-
        if (bot.brickCount == 0)
        {
            bot.ChangeState(new SeekBrickState());
        }
    }

    public void OnExit(Bot bot)
    {
    }

}
