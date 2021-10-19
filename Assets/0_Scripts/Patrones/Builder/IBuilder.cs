using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
