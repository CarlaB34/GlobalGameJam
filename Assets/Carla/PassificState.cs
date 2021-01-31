using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassificState : State
{

    private List<GameObject> m_ObjtRamasserPassif;
    //on va prendre des objets et les apporter a l'altere
    public PassificState(List<GameObject> p_Objet)
    {
        m_ObjtRamasserPassif = p_Objet;
    }

    //il faudrais faire un foreach
}
