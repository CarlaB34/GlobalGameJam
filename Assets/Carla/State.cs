using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State 
{

    /* private Action m_StateEndCallback;

     // Start is called before the first frame update
     void Start()
     {
         m_StateEndCallback = StateEnd;
     }

     // Update is called once per frame
     void Update()
     {
         m_StateEndCallback.Invoke();
     }

     public void StateEnd()
     {

     }*/
    public virtual string m_StateName
    {
        get { return "Oui"; }
    }

    private List<Transition> m_transitions = new List<Transition>();

    public State CheckTransitions(FSM p_FSM, State p_CurrentState)
    {
        //Est-ce que tout est ok pour changer vers le state trigger ? 
        //Ont check toutes les conditions pour toruver laquel a été trigger puis ont transitionne vers le state accordé a cette condition.
        //Si non alors ont s'en fous c'est que y'a pas eu de changement donc ont renvoit rien.
        foreach (Transition l_Transition in m_transitions)
        {
            if (l_Transition.CanTransitionTo(p_FSM))
            {
                p_FSM.CurrentState = l_Transition.StateTo;
                return l_Transition.StateTo;
            }
        }
        return null;
    }

    public Transition AddTransition(State p_State, TransitionCondition p_Condition)
    {
        Transition l_NewTransition = new Transition(p_State);
        l_NewTransition.AddCondition(p_Condition);
        m_transitions.Add(l_NewTransition);//erreur ici de null reference
        return default;
    }

    public virtual void OnStateEnter(FSM p_FSM, GameObject p_Obj) { }

    public virtual void OnStateUpdate(FSM p_FSM, GameObject p_Obj, float p_DeltaTime) { }

    public virtual void OnStateExit(FSM p_FSM, GameObject p_Obj) { }

}
