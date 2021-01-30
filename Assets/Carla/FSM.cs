using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM 
{
    private State m_CurrentState;

    private Dictionary<string, bool> m_Parameters = new Dictionary<string, bool>();

    public State CurrentState
    {
        get { return m_CurrentState; }
        set { m_CurrentState = value; }
    }

    public Dictionary<string, bool> Parameter
    {
        get { return m_Parameters; }
        set { m_Parameters = value; }
    }

    public void SetParameter(string p_ParameterName, bool p_ParameterValue)
    {
        if (m_Parameters.ContainsKey(p_ParameterName))
        {
            m_Parameters[p_ParameterName] = p_ParameterValue;
        }
        else
        {
            m_Parameters.Add(p_ParameterName, p_ParameterValue);
        }
    }

    public bool GetParameter(string p_ParameterName)
    {
        if (m_Parameters.TryGetValue(p_ParameterName, out bool l_Value))
        {
            return l_Value;
        }
        return false;
    }

    public void Initialization(State p_StateToInit)
    {
        m_CurrentState = p_StateToInit;
    }


    public void Update(float p_DeltaTime, GameObject p_GO)
    {
        //L'update ou ont voit le state actuel pour un éventuel changement.
        //Ont prend le State actuel et ont le lance chaque frame.
        m_CurrentState.CheckTransitions(this, m_CurrentState);
        m_CurrentState.OnStateEnter(this,p_GO);
        m_CurrentState.OnStateUpdate(this, p_GO, p_DeltaTime);

    }


}
