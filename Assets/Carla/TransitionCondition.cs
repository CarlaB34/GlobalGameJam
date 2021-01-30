using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionCondition
{
    public abstract bool Validate(FSM p_FSM);

}


public class TransitionCondition_CheckBool : TransitionCondition
{
    private string m_ParameterName;
    private bool m_ExpectedValue;

    public TransitionCondition_CheckBool(string p_ParameterName, bool p_ExpectedValue)
    {
        m_ParameterName = p_ParameterName;
        m_ExpectedValue = p_ExpectedValue;
    }

    public override bool Validate(FSM p_FSM)
    {

        return (p_FSM.GetParameter(m_ParameterName) == m_ExpectedValue);

    }

}