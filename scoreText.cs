using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo controla as ações do Texto de pontuação do jogo
//Linguagem C#
//Ultima revisão: 17/10/2018

public class scoreText : MonoBehaviour {

	//Declara o objeto de texto do jogo
	//O SerializeField mostra no Inspector mesmo sendo variavel privada
	[SerializeField]
	private Text scoreTxt;

	//Declara o objeto scoreManager para poder ser usado no codigo
	private scoreManager scoreManager;

	//Executa está função quando a cena é inicia
	void Start () 
	{
		//Procura o objeto scoreManager e instancia
		scoreManager = FindObjectOfType<scoreManager> ();

		//Define a que está escrito no texto com o valor da variavel score do codigo scoreManager
		scoreTxt.text = "" + scoreManager.Score;
	}
}
