using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerupState
{
    void PowerupEffect();

    void PowerupExpiration();

    void OnTriggerEnter2D(Collider2D hitinfo);

    void ToNormalPlayer();

    void ToBigPlayer();

    void ToShootingPlayer();

    void ToIncinviblePlayer();
}
