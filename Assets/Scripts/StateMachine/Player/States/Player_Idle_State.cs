using UnityEngine;
using System.Collections;

namespace StateMachine.Player
{
    public class Player_Idle_State : Player_Base_State
    {
        protected override string stateName
        {
            get
            {
                return context.Player.Name + " Idle";
            }
        }
    }
}