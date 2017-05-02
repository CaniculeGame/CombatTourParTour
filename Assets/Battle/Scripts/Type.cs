using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Type
{
    public enum E_TypeEnum
    {
        EAU = 0,
        FEU = 1,
        PLANTE = 2, 
        NORMAL = 3
    }

    private float[] tableau_ = new float[4];
    private E_TypeEnum tp_;

    public abstract float Modificateur(E_TypeEnum tp);

    public E_TypeEnum Genre { get { return tp_; } set { tp_ = value; } }
    public float[] Tableau { get { return tableau_; } set { tableau_ = value; } }
}
