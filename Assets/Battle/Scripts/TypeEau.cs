using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeEau : Type
{

    public TypeEau()
    {
        this.Tableau[(int)E_TypeEnum.EAU]    = 0.5f;
        this.Tableau[(int)E_TypeEnum.FEU]    = 2.0f;
        this.Tableau[(int)E_TypeEnum.NORMAL] = 1.0f;
        this.Tableau[(int)E_TypeEnum.PLANTE] = 0.5f;

    }



    public override float Modificateur(E_TypeEnum tp)
    {
        return Tableau[(int)tp];
    }
}
