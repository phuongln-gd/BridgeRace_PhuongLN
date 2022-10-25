using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBrickState : IState
{
    int targetBricks;
    public void OnEnter(Bot bot)
    {
        targetBricks = Random.Range(4, 7);
        bot.SetDestination(bot.GetBrickPoint());
    }

    public void OnExecute(Bot bot)
    {
        if (bot.IsDestination())
        {
            if (bot.brickCount < targetBricks)
            {
                Debug.Log("find brick more");
                bot.SetDestination(bot.GetBrickPoint());
            }
            else
            {
                Debug.Log("fill brick");
                bot.ChangeState(new BuildBridgeState());
            }
        }
    }

    public void OnExit(Bot bot)
    {
    }
}
