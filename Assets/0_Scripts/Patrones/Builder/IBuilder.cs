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
    void BuildCollectible();

    void BuildCoin();
    
    void BuildExtraLife();

    void BuildHighJump();

    void BuildShield();
}
