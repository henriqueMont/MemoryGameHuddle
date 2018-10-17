using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo é o responsavel pelo envio das informações ao servidor 
//Linguagem: C#
//Ultima revisão: 17/10/2018

[Serializable]
public class dataClass : MonoBehaviour{


	//Declara o nivel em que o jogador está
	public int level;

	//Declara a pontuação do jogador
	public int score;

	//Declara o nome do jogado
	public string playerName=null;


	private string namePlayer=null;
//	string httpSend = "https: //us-central1-huddle-team.cloudfunctions.net/api/memory/henrique.m.silva1@gmail.com";
	//Armazena o valor da json em uma string
	string jsonFix;

	//Declara o campo usado para inserir o nome do jogador
	[SerializeField]
	private InputField nameField = null;

	//Declara o objeto gameManager para poder ser usado no codigo
	private scoreManager scoreManager;

	//Declara o texto que irá mostrar se o upload da JSON foi realizado
	public Text uploadComplete;

	public void Start()
	{
		
		scoreManager = FindObjectOfType<scoreManager> ();
	}

	//Empacota as informações em um JSON e para poder ser enviada para um endpoint
	public void Send()
	{
		//Cria um objeto que ira armazenar as informações
		dataClass dataObj  = new dataClass ();

		//Adiciona ao objeto o valor do nivel
		dataObj.level = 1;

		//Adiciona ao objeto a pontuação obtida no scoreManager
		dataObj.score = scoreManager.Score;

		//Adiciona ao objeto o nome do namePlayer
		dataObj.playerName = ""+namePlayer;

		//Transforma o objeto e suas informações em JSON
		string json = JsonUtility.ToJson (dataObj);

		//Exibe no console as informações como estão sendo enviadas
		Debug.Log (json);

		//Armazena o valor da JSON na string jsonFix
		jsonFix = json;

		//Chama a função para iniciar a corotina de envio
		SendTo ();
	}
		
	//Chama a corotina
	public void SendTo()
	{
		//Chama a corotina
		StartCoroutine (Upload ());
	}

	public void NameTo()
	{
		string name = nameField.text;
		namePlayer = name;
	}

	//Corotina que faz o envio do JSON para o endpoint
	IEnumerator Upload()
	{
		
		//Executa a conexão com o endpoint/link e envia o JSON para ele
		UnityWebRequest www = UnityWebRequest.Post ("https://us-central1-huddle-team.cloudfunctions.net/api/memory/henrique.m.silva1@gmail.com",jsonFix);

		//Chama o retorno dda conexão
		yield return www.SendWebRequest ();

		//Verifica se a conexão deu erro ou se o http deu erro
		//Se sim
		if (www.isNetworkError || www.isHttpError) 
		{
			//Informa o erro que apresentou
			uploadComplete.text = www.error;
			Debug.Log(www.error);

		} 
		//Se não
		else 
		{
			//Informa quee conseguiu enviar
			uploadComplete.text = "Upload Complete";
			Debug.Log("Upload Complete");
		}
	}
}
