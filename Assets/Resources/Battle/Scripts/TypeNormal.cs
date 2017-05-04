using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeNormal : Type
{

    public TypeNormal()
    {
        this.Tableau[(int)E_TypeEnum.EAU]    = 1.0f;
        this.Tableau[(int)E_TypeEnum.FEU]    = 1.0f;
        this.Tableau[(int)E_TypeEnum.NORMAL] = 1.0f;
        this.Tableau[(int)E_TypeEnum.PLANTE] = 1.0f;

        this.Genre = E_TypeEnum.NORMAL;
    }



    public override float Modificateur(E_TypeEnum tp)
    {
        return Tableau[(int)tp];
    }
}
