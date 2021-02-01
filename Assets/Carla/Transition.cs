using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    private State m_To;

    public State StateTo
    {
        get { return m_To; }

    }
    private List<TransitionCondition> m_Conditions = new List<TransitionCondition>();

    public bool CanTransitionTo(FSM p_FSM)
    {
        //Je chekc mes conditions et si y'a une qui est pas bonne ont stop tout et ont peut pas transitionner vers le m_To.
        foreach (TransitionCondition l_Condition in m_Conditions)
        {
            if (!l_Condition.Validate(p_FSM))
            {
                return false;
            }
        }
        return true;
    }

    public Transition(State p_State)
    {
        m_To = p_State;
    }

    public void AddCondition(TransitionCondition p_Condition)
    {
        m_Conditions.Add(p_Condition);
    }

}