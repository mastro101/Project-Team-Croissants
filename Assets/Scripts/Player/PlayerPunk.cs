using UnityEngine;
using System.Collections;

public class PlayerPunk : PlayerBase
{
    [SerializeField]
    GameObject trapPrefab;

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
        Instantiate(trapPrefab, transform.position + new Vector3 (0, 1, 0), Quaternion.Euler(0, 0, 0));
        FindObjectOfType<AudioManager>().Play("PunkAbility");

        SM.SetBool("Ability", false);
    }
}
