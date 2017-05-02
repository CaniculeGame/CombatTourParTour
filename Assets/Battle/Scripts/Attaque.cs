using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque
{

    public enum E_TypeAttaque
    {
        SOIN = 1,
        ATTAQUER = 2,
        DEF = 4,
        ESQUIVE = 8,
        PRECISION = 16,
        CHANGEATT = 32
    }


    private string intitule_;
    private float mp_;
    private float power_;
    private Type type_;
    private E_TypeAttaque typeAtt_;
    private int NumeroAnimationEnnemie_;
    private int NumeroAnimationAttaquant_;

    public Attaque(float mp, float power, string nom, Type tp, E_TypeAttaque typeAtt, int NumeroAnimationAttaquant, int NumeroAnimationEnnemie)
    {
        intitule_ = nom;
        mp_    = mp;
        power_ = power;
        type_  = tp;
        typeAtt_ = typeAtt;
        NumeroAnimationEnnemie_ = NumeroAnimationEnnemie;
        NumeroAnimationAttaquant_ = NumeroAnimationAttaquant;
    }


    public float Mp { get { return mp_; } }
    public float Power { get { return power_; } }
    public string Intitule { get { return intitule_; } }
    public Type TypeDAttaque { get { return type_; } }
    public E_TypeAttaque CategorieDAttaque { get { return typeAtt_; } }
    public int NumeroAnimationAttaquant { get { return NumeroAnimationAttaquant_; } }
    public int NumeroAnimationEnnemie { get { return NumeroAnimationEnnemie_; } }

}

