using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo é o responsavel pelo controle da pontuação do jogo
//Linguagem: C#
//Ultima revisão: 17/10/2018

public class scoreManager : MonoBehaviour {

	//Declara e defini a pontuação do jogo
	private int score = 0;

	//Declara e defini os pontos perdidos a cada par errado
	//O SerializeField mostra no Inspector mesmo sendo variavel privada
	[SerializeField]
	private int bonusScoreLost = 5;

	//Declara e defini os pontos obtidos a cada par certo
	[SerializeField]
	private int scorePairCard = 10;

	//Declara e defini a score que é manipulada no jogo
	private int scoreCard=0;

	//Declara o objeto timeCounter para poder ser usado no codigo
	private timeCounter timeCounter;

	//Declara o objeto de texto do jogo
	public Text scoreTxt;

	//Metodo para acessar a variavel privada de score
	public int Score
	{
		//Pega o score e retorna para o metodo
		get{return score; }

		//Coloca e atualiza o valor de score
		set{score = value; }
	}

	//Executa está função quando a cena é inicia
	void Start()
	{
		//Procura o objeto timeCounter e instancia
		timeCounter = FindObjectOfType<timeCounter> ();
	}

	//Adiciona pontos na scoreCard, para quando acerta o par
	public void AddScore()
	{
		//Pega o valor da scoreCard e soma com scorePairCard e coloca o resultado em scoreCard mesmo
		scoreCard += scorePairCard;
	}

	//Subtrai pontos na scoreCard, para quando erra o par
	public void SubScore()
	{
		//Pega o valor da scoreCard e subtrai com scorePairCard e coloca o resultado em scoreCard mesmo
		scoreCard -= bonusScoreLost;
	}

	//Calculando o resultado da pontuação do jogador 
	public void CalculateEndScore()
	{
		//Faz o calculado da score do Player, somando o scoreCard com o tempo que ainda restou e o resultado é armazenado em score
		score = (scoreCard + timeCounter.timeCounted);

		//Adiciona e aloca na memoria o valor de score do jogador
		PlayerPrefs.SetInt ("Scr", score);
	}

	//Executa está função a cada frame da cena
	void Update()
	{
		//Define a que está escrito no texto com o valor da variavel score do codigo scoreCard
		scoreTxt.text = "Score: " + scoreCard;
	}
}
