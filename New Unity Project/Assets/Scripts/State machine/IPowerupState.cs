using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerupState
{
    void PowerupEffect();

    void ToNormalPlayer();

    void ToBigPlayer();

    void ToShootingPlayer();

    void ToInvinciblePlayer();
}
