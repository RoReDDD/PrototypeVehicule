using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class QuestGoal
{
    public GoalType goalType;

    public int currentAmount;
    public int requiredAmount;
    public Transform obejctifLocate;

    public bool isReached()
    {

        return (currentAmount >= requiredAmount);
    }
    public bool isUnloaded()
    {

        return (currentAmount <= requiredAmount);
    }

    public void ChargeCollect()
    {
        if (goalType == GoalType.gathering)
        {
            currentAmount++;
        }
    }

    public void ChargeUnload()
    {
        if (goalType == GoalType.unload)
        {
            currentAmount--;
        }
    }

    public void ChangeGoalType(GoalType newGoal)
    {
        switch (newGoal)
        {
            case GoalType.escort:
                
                break;

            case GoalType.gathering:
                isReached();
                break;

            case GoalType.unload:
                isUnloaded();
                break;
        }
    }
}
public enum GoalType
{
    escort,
    gathering,
    unload

}


