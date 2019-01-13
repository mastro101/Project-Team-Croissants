using UnityEngine;
using System.Collections;

public class PlayerPunk : PlayerBase
{
    public override int ID
    {
        get
        {
            return 2;
        }
    }

    public override string Name
    {
        get
        {
            return "Punk-ina";
        }
    }

    public override void Ability()
    {


        SM.SetBool("Ability", false);
    }
}
