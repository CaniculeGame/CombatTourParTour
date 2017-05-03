/*********************************************************
 * 
 * 						DictionnaireLang.cs
 *  
 * *******************************************************
 * 
 * Dictionnaire contenant toutes les traduction des textes.
 * A appeller a chaque fois qu'on a a ecrire un texte.
 * 
 * Lors de sa creation, Il faut instancier et charger le fichier
 * de language. 
 * 
 * structure fichier :
 * <doc>
 * <valeur name="text1">
 * 	<langue1>val</langue1>
 *  <langue2>val</langue2>
 *  ...
 * </valeur>
 * ...
 *</doc>
 *
 * nb: c'est un singleton 
 *
 * *******************************************************/



using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;


public class DictionnaireLang 
{

	private string langue_ = "fr";
	private string path_ = "";
	private bool   EstEnRechargementAuto = true;

	//dictionnaire complet en memoire
	Dictionary<string,string> dico_ = null;



	// on instancie la classe
	private static DictionnaireLang instance_ = null;
	public static DictionnaireLang Lang
	{
		get
		{
			if( instance_ == null)
			{
				instance_ = new DictionnaireLang ();
			} 
			return instance_;
		}
	}

	public string Langue
	{
		get{ return langue_;}
		//changement de langue donc rechargement du dico si option active
		set
		{ 
			langue_ = value; 
			if(EstEnRechargementAuto && path_ != null && path_ != "")
				ReloadDico();
		} 
	}


	public bool ReChargerDicoAuto
	{
		get{ return EstEnRechargementAuto;}
		set{ EstEnRechargementAuto = value;} 
	}


	public void ReloadDico()
	{
		LoadFileXml (path_);
	}


	//appeler pour creation du fichier
	public void LoadFileXml(string xmlPath)
	{
		path_ = xmlPath;
		XmlDocument doc = new XmlDocument();
		if (langue_ == null || langue_ == "" || path_ =="" || path_ == null) 
		{
			Debug.LogError ("Erreur: language invalide");
			return;
		}

		try
		{
			dico_ = new Dictionary<string, string> ();

			//open file en fct de la paltforme cible
			//if (Application.platform == RuntimePlatform.Android)
			//{
				TextAsset txtTmp = (TextAsset)Resources.Load(xmlPath);
				doc.LoadXml(txtTmp.text);
			/*}
			else
			{
				doc.Load(xmlPath);
			}*/

			//si ouverture reussi alors 
			if (doc != null) 
			{
				//on recupere tous les noeuds
				XmlNodeList list = doc.GetElementsByTagName("valeur");
				//on parcours chaque noeud "valeur" (= pour chaque valeur faire)
				foreach( XmlNode element  in list )
				{
					//recuperation des noeuds enfant (=langue)
					XmlNodeList child = element.ChildNodes; 
						
					foreach( XmlNode valeur in child) // pour chaque langue faire
					{
						//chaque ellement a plusieurs attribut. Il faut prendre le bon en fct de la langue choisie
						if(valeur.Name == langue_) // si on a la bonne langue on enregistre ds le dico
						{
							dico_.Add(element.Attributes["name"].Value,valeur.InnerText);
							break;
						}

					}

				}

			}

		}
		catch(Exception e)
		{
			Debug.LogError ("Erreur : chargement du fichier de langue echoué!! chemin= " + xmlPath + "  " + e);
		}

	}


	//retourne le text dans la langue choisie. La langue figure dans les prefs
	public string Text(string value)
	{
		try
		{
			if(dico_ != null)
			{
				//recherche de la valeur dans le livre

				return dico_[value];
			}
			else
				return "Error";
		}
		catch(Exception e)
		{
			Debug.Log ("Erreur : dictionnaire clé non trouvee! "+ value + "  " + e);
			return "Error";
		}
	}




	private DictionnaireLang(){}



}
