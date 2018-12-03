using UnityEngine;
using System.Collections;

public interface IPowerUp
{
    void Effect(IPlayer player);
    void OnTake();
}
