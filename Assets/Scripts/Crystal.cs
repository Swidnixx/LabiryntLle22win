using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Pickup
{
    public override void Pick()
    {
        GameManager.Instance.AddCrystal();
        base.Pick();
    }
}
