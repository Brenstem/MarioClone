using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerupState
{
    // Active function
    void PowerupEffect();

    // Exit function
    void ToNormalPlayer();
}
