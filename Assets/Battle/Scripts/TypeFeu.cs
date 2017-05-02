using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeFeu : Type
{

    public TypeFeu()
    {
        this.Tableau[(int)E_TypeEnum.EAU]    = 0.5f;
        this.Tableau[(int)E_TypeEnum.FEU]    = 0.5f;
        this.Tableau[(int)E_TypeEnum.NORMAL] = 1.0f;
        this.Tableau[(int)E_TypeEnum.PLANTE] = 2.0f;
    }



    public override float Modificateur(E_TypeEnum tp)
    {
        return Tableau[(int)tp];
    }
}
