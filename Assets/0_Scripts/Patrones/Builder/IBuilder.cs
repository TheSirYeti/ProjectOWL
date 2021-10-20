using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public interface IChallengeGenerator
{
    void BuildScoreChallenge();

    void BuildDistanceChallenge();
}

public interface ICollectibleBuilder
{
    void BuildSpeed(float speed);
    void BuildValue(float value);
    void BuildDuration(float duration);
    void BuildJumpValue(float jumpValue);
    Token BuildCoin();
    ExtraLife BuildExtraLife();
    HighJump BuildHighJump();
    Shield BuildShield();
}
