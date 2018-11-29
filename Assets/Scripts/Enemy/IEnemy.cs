using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {

    GameObject gameObject { get; }
	float MovementSpeed { get; set; }
    IPlayer PlayerToFollow { get; }
}
