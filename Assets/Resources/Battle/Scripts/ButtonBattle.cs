using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBattle
{
    public enum E_TypeAttaque
    {
        SOIN = 1,
        ATTAQUER = 2,
        DEF = 4,
        ESQUIVE = 8,
        PRECISION = 16,
        CHANGEATT  = 32
    }



    public bool Execute(ref Personnage Enemie, ref Personnage joueur, int numeroAttaque)
    {
        bool res = false;

        if (joueur.Mana >= joueur.AttaquesList[numeroAttaque].Mp)
        {

            if (((E_TypeAttaque)joueur.AttaquesList[numeroAttaque].CategorieDAttaque & E_TypeAttaque.ATTAQUER) != 0)
                res = Attaquer(ref Enemie, ref joueur, numeroAttaque);

            if (((E_TypeAttaque)joueur.AttaquesList[numeroAttaque].CategorieDAttaque & E_TypeAttaque.DEF) != 0)
                res = ChangerDefenseEnnemie(ref Enemie, numeroAttaque);

            if (((E_TypeAttaque)joueur.AttaquesList[numeroAttaque].CategorieDAttaque & E_TypeAttaque.ESQUIVE) != 0)
                res = ChangeEsquiveEnnemie(ref Enemie, numeroAttaque);

            if (((E_TypeAttaque)joueur.AttaquesList[numeroAttaque].CategorieDAttaque & E_TypeAttaque.PRECISION) != 0)
                res = ChangerPrecisionEnnemie(ref Enemie, numeroAttaque);

            if (((E_TypeAttaque)joueur.AttaquesList[numeroAttaque].CategorieDAttaque & E_TypeAttaque.SOIN) != 0)
                res = Soigner(ref joueur, numeroAttaque);

            if (((E_TypeAttaque)joueur.AttaquesList[numeroAttaque].CategorieDAttaque & E_TypeAttaque.CHANGEATT) != 0)
                res = ChangeAttaqueEnnemie(ref Enemie, numeroAttaque);
        }

        Debug.Log((E_TypeAttaque)joueur.AttaquesList[numeroAttaque].CategorieDAttaque + "  " + res);
        return res;
    }



    // TODO à redefinir
    public bool Attaquer(ref Personnage Enemie, ref Personnage joueur,int numAtt)
    {
        bool res = false;

        Debug.Log(joueur.Mana +"  "+ joueur.AttaquesList[numAtt].Mp);
        if (joueur.Mana >= joueur.AttaquesList[numAtt].Mp)
        {
            res = true;

            //faire calcul en fonction de l'enemie si esquive fail
            float precision = joueur.Precision * joueur.Precision / Enemie.Esquive;
            bool toucher = UnityEngine.Random.Range(0.0f, 1.0f) <= precision ? true : false;
            if (toucher)
            {
                Debug.Log(((joueur.AttaquesList[numAtt].Power * 100 * joueur.Force * 100) / (Enemie.Def * 100) + 2) * joueur.Type.Modificateur(Enemie.Type.Genre));
                Enemie.Pv -= ((joueur.AttaquesList[numAtt].Power * 100 * joueur.Force * 100) / (Enemie.Def * 100) + 2) * joueur.Type.Modificateur(Enemie.Type.Genre) / 100;
            }
        }

        return res;
    }

    // TODO à redefinir
    public bool Soigner(ref Personnage joueur, int numAtt)
    {
        joueur.Pv += joueur.AttaquesList[numAtt].Power;
        if (joueur.Pv > joueur.PvBase) 
            joueur.Pv = joueur.PvBase;

        return true;
    }


    // TODO à redefinir
    public bool ChangerPrecisionEnnemie(ref Personnage Enemie, int numAtt)
    {
        Enemie.Precision -= 0.01f; 
        if (Enemie.Precision >= 0.0f)
            Enemie.Precision = 0.01f;

        return true;
    }

    // TODO à redefinir
    public bool ChangerDefenseEnnemie(ref Personnage Enemie, int numAtt)
    {
        Enemie.Def -= 0.01f;
        if (Enemie.Def >= 0.0f)
            Enemie.Def = 0.01f;

        return true;
    }

    // TODO à redefinir
    public bool ChangeEsquiveEnnemie(ref Personnage Enemie, int numAtt)
    {
        Enemie.Esquive -= 0.01f;
        if (Enemie.Esquive >= 0.0f)
            Enemie.Esquive = 0.01f;

        return true;
    }

    // TODO à redefinir
    public bool ChangeAttaqueEnnemie(ref Personnage Enemie, int numAtt)
    {
        Enemie.Force -= 0.01f;
        if (Enemie.Force >= 0.0f)
            Enemie.Force = 0.01f;

        return true;
    }

}
