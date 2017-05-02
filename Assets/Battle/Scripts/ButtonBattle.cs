using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBattle 
{
    public enum E_TypeAttaque
    {
        FEU    = 1,
        EAU    = 2,
        TERRE  = 4,
        PLANTE = 8
    }

    private float useMp_ = 0.0f;
    private float power_ = 1.0f;
    private Type type_ = null;
    private string txt_ = "";
 


    public void Configure(float useMp, float power, string nom, Type type)
    {
        power_ = power;
        useMp_ = useMp;
        type_ = type;
        txt_ = nom;

    }

    public ButtonBattle(float useMp, float power, string nom, Type type)
    {
        power_ = power;
        useMp_ = useMp;
        type_  = type;
        txt_   = nom;
    }


    public bool Execute( Personnage Enemie, Personnage joueur)
    {
        bool res = false;


        if (joueur.Mana >= useMp_ )
        {
            res = true;
            
            //faire calcul en fonction de l'enemie
            Enemie.Pv -= power_;
        }

        Debug.Log(txt_+"  "+res);
        return res;
    }

    public float Mana { get { return useMp_; } set{ useMp_ = value; } }

}
