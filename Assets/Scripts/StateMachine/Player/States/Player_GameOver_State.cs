using UnityEngine;
using System.Collections;

namespace StateMachine.Player
{
    public class Player_GameOver_State : Player_Base_State
    {
        protected override string stateName
        {
            get
            {
                return context.Player.ToString() + " GameOver";
            }
        }
    }
}