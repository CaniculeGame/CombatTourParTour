using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModificationPersonnageManager : MonoBehaviour
{

    public Text titre;
    public Text sousTitre;
    public Text attributTitre;
    public Text info;
    public Text titreListeA;
    public Text titreListeB;

    public Button continuer;

    public ScrollList otherShop;
    public ScrollList shop;
    public GameObject personnageA;
    public GameObject personnageB;
    public GameObject panelAttributPerso;


    public void Eteindre()
    {
        //activation des dependance
        personnageB.SetActive(false);
        personnageA.SetActive(false);

        //positionner animation
        titre.transform.parent.gameObject.SetActive(false);

    }

    public void Demarrer()
    {

        //activation des dependance
        personnageA.SetActive(true);
        personnageA.GetComponent<Animator>().SetInteger("numeroAnimation", 0);
        personnageA.transform.position = new Vector3(-1.52f, 3f, 0.0f);

        //positionner animation
        titre.transform.parent.gameObject.SetActive(true);
    }


    public void Configurer()
    {
        //chargement du dictionnaire de lang
        DictionnaireLang.Lang.Langue = "fr";
        DictionnaireLang.Lang.LoadFileXml("Dictionnaire/language");

        //attribution des noms pour les titres suivant un dictionnaire
        titre.text = DictionnaireLang.Lang.Text("main_titre_fiche_perso");
        sousTitre.text = DictionnaireLang.Lang.Text("sub_titre_fiche_perso");
        attributTitre.text = DictionnaireLang.Lang.Text("attribut");
        info.text = DictionnaireLang.Lang.Text("explain");
        titreListeA.text = DictionnaireLang.Lang.Text("listeAtqA");
        titreListeB.text = DictionnaireLang.Lang.Text("listeAtqB");
        continuer.GetComponentInChildren<Text>().text = DictionnaireLang.Lang.Text("continuer");

        //creation de la liste
        LoadAttaqueButton("FichePerso/Text/attaqueList");

        //afficher les attribut du personnage
        GameObject[] txtAttribut = new GameObject[panelAttributPerso.transform.childCount];
        for (int i = 0; i < panelAttributPerso.transform.childCount; i++)
        {
            if (panelAttributPerso.transform.GetChild(i).name == "NomText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = personnageA.GetComponent<Personnage>().Nom;
            else if (panelAttributPerso.transform.GetChild(i).name == "PartieText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = personnageA.GetComponent<Personnage>().Partie;
            else if (panelAttributPerso.transform.GetChild(i).name == "PvText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("pv") + (personnageA.GetComponent<Personnage>().PvBase * 100).ToString();
            else if (panelAttributPerso.transform.GetChild(i).name == "MpText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("mp") + (personnageA.GetComponent<Personnage>().ManaBase * 100).ToString();
            else if (panelAttributPerso.transform.GetChild(i).name == "ForceText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("force") + (personnageA.GetComponent<Personnage>().ForceBase * 100).ToString();
            else if (panelAttributPerso.transform.GetChild(i).name == "EsquiveText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("esquive") + (personnageA.GetComponent<Personnage>().EsquiveBase * 100).ToString();
            else if (panelAttributPerso.transform.GetChild(i).name == "VitText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("vitesse") + (personnageA.GetComponent<Personnage>().VitesseBase * 100).ToString();
            else if (panelAttributPerso.transform.GetChild(i).name == "PrecisionText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("precision") + (personnageA.GetComponent<Personnage>().PrecisionBase * 100).ToString();
            else if (panelAttributPerso.transform.GetChild(i).name == "DefenseText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("defense") + (personnageA.GetComponent<Personnage>().DefBase * 100).ToString();
            else if (panelAttributPerso.transform.GetChild(i).name == "TypeText")
                panelAttributPerso.transform.GetChild(i).GetComponent<Text>().text = DictionnaireLang.Lang.Text("type_text") + personnageA.GetComponent<Personnage>().TypeString;
        }


        //demarrer le programme
        Demarrer();
    }

    // Use this for initialization
    void Start()
    {
        //  Configurer();
    }


    private void LoadAttaqueButton(string path)
    {
        TextAsset txt = Resources.Load<TextAsset>(path);
        if (txt != null)
        {

            string[] tps = txt.text.Split('\n');
            for (int i = 0; i < tps.Length; i++)
            {
                string[] str = tps[i].Split(':');
                if (str[0][0] != '#')
                {
                    Item item = new Item();
                    item.Intitule = str[1];
                    item.Power = float.Parse(str[2]);
                    item.IntituleType = str[3];
                    item.Mana = float.Parse(str[4]);
                    item.Caracteristique = str[5];
                    item.animationA = int.Parse(str[6]);
                    item.animationB = int.Parse(str[7]);

                    otherShop.AddItem(item, otherShop);
                }
            }

            otherShop.RefreshDisplay();
        }
        else
            Debug.Log("est null");

    }


    public List<Item> getListA()
    {
        return otherShop.itemList;
    }

    public List<Item> getListB()
    {
        return shop.itemList;
    }

}
