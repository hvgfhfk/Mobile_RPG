using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTemper
{
    public Animator monsterAnimator;

    public int hp;
    public int offensivePower;
    public int defensivePower;
    public int haveExp;
    public int amountRecovery;
}

public class SlimeType : MonsterTemper
{
    public void SlimeCompetencyValue()
    {
        hp = 100;
        offensivePower = 10;
        defensivePower = 5;
        haveExp = 10;
        amountRecovery = 10;
    }
}

public class ShellType : MonsterTemper
{
    public void ShellCompetencyValue()
    {
        hp = 130;
        offensivePower = 13;
        defensivePower = 5;
        haveExp = 15;
        amountRecovery = 15;
    }
}