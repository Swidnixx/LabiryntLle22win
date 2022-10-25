using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public uint time = 10;
    public override void Pick()
    {
        GameManager.Instance.FreezeTime(time);
        base.Pick();
    }
}
