using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo controla as ações e eventos gerais do jogo como verificação dos pares e ações das cartas
//Linguagem C#
//Ultima revisão: 17/10/2018

public class gameManager : MonoBehaviour {

	//Recebe e armazena o objeto da primeira carta clicada
	private GameObject firstCard = null;

	//Recebe e armazena o objeto da segunda carta clicada
	private GameObject secondCard = null;

	//Declara o total de cartas no jogo
	private int cardsTotal;

	//Armazena se as cartas podem ser viradas ou não
	private bool canFlip = true;

	//Declara e define o tempo em que as cartas irão virar de volta, ou seja o atraso
	//O SerializeField mostra no Inspector mesmo sendo variavel privada 
	[SerializeField]
	private float timeBetweenFlips = 0.75f;

	//Declara o objeto gameManager para poder ser usado no codigo
	[SerializeField]
	private scoreManager scoreManager;

	//Declara e define o objeto/painel que aparece quando o jogador vencer o jogo
	[SerializeField]
	private GameObject winMenu;

	//Declara o objeto timeCounter para poder ser usado no codigo
	[SerializeField]
	private timeCounter timeCounter;

	//Declara e define o efeito de particulas das estrelas
	public GameObject star;

	//Metodo para acessar a variavel privada de canFlip
	public bool CanFlip
	{
		//Pega o canFlip e retorna para o metodo
		get{return canFlip; }

		//Colocar e atualiza o valor de canFlip
		set{canFlip = value; }
	}

	//Metodo para acessar a variavel privada de canFlip
	public int CardsTotal
	{
		//Pega o cardsLeft e retorna para o metodo
		get{return cardsTotal; }

		//Colocar e atualiza o valor de cardsLeft
		set{cardsTotal = value; }
	}

	//Executa está função quando a cena é inicia
	void Start()
	{
		//Procura o objeto scoreManager e instancia
		scoreManager = FindObjectOfType<scoreManager> ();

		//Procura o objeto timeCounter e instancia
		timeCounter = FindObjectOfType<timeCounter> ();
	}

	//Armazena os dois objetos carta que foi clicado e compara se são sapres
	public void AddCard(GameObject card)
	{
		//Se o objeto da primeira carta clicada estiver vazio
		if (firstCard == null) 
		{
			//Armazena a carta clicada no objeto de primeira carta
			firstCard = card;
		} 
		//Se não
		else 
		{
			//Armazena a carta clicada no objeto de segunda carta
			secondCard = card;

			//Define que não poderá virar mais nenhuma carta
			canFlip = false;

			//Chama a função de checagem se são par ou não
			//Se for par
			if (CheckIfMatch ()) 
			{
				//Chama a função de subtrair as cartas
				DecreaseCardCount ();

				//Manda adiciona a pontução no codigo scoreManager
				scoreManager.AddScore();

				//Inicia a corotina de desativação das cartas
				StartCoroutine (DeactivateCards ());
			}
			//Se não forem par
			else 
			{
				//Manda subtrair pontos da pontuação no codigo scoreManager
				scoreManager.SubScore();

				//Executa a corotina de virar as cartas devolta
				StartCoroutine (FlipCards ());
			}
		}
	}

	//Corotina que desativa as cartas da cena, quando você já encontrou os pares.
	IEnumerator DeactivateCards()
	{
		//Instancia o efeito de estrelas na primeira carta
		Instantiate (star, firstCard.transform.position, firstCard.transform.rotation);

		//Instancia o efeito de estrelas na segunda carta
		Instantiate (star, secondCard.transform.position, secondCard.transform.rotation);

		//Aguarda um tempo para as cartas serem desativadas
		yield return new WaitForSeconds (timeBetweenFlips);

		//Desativa a primeira carta
		firstCard.SetActive (false);

		//desativa a segunda carta
		secondCard.SetActive (false);

		//Chama função para resetar as variaveis
		Reset ();
	}

	//Corotina que vira as cartas de volta
	IEnumerator FlipCards()
	{
		//Aguarda um tempo para as cartas serem viradas de volta
		yield return new WaitForSeconds (timeBetweenFlips);

		//Pega o componente de codigo da primeira carta e manda virar de volta com a função ChangeSide
		firstCard.GetComponent<cardController> ().ChangeSide ();

		//Pega o componente de codigo da segunda carta e manda virar de volta com a função ChangeSide
		secondCard.GetComponent<cardController> ().ChangeSide ();

		//Chama a função para resetar as variaveis
		Reset ();
	}

	//Está função subtrai o numero de cartas que já foi descoberto os pares, do total de cartas
	public void DecreaseCardCount()
	{
		//Subtrai duas cartas do total
		cardsTotal -= 2;

		//Verifica se o total de cartas chegar a zero ou menor
		//Se sim
		if (cardsTotal <= 0) 
		{
			//Define que o jogo acabou
			//Ativa o painel de vitoria
			winMenu.SetActive(true);

			//Manda para parar de contar o tempo para o codigo do timeCounter
			timeCounter.CountTime = false;

			//Manda o scoreManager executar função que calcula o resultado da partida
			scoreManager.CalculateEndScore ();
		}
	}

	//Faz a verificação se as cartas são pares, retornando falso ou verdadeiro
	bool CheckIfMatch()
	{
		//Se a primeira carta e a segunda forem iguais a variavel cardName
		if (firstCard.GetComponent<cardController> ().CardName == secondCard.GetComponent<cardController> ().CardName) 
		{
			//retorna verdadeiro para CheckIfMatch
			return true;
		}
		//Se não forem iguais a variavel cardName
		else 
		{
			//retorna falso para CheckIfMatch
			return false;
		}
	}

	//Reseta as variaveis e os objetos para pcontinuar o jogo
	void Reset()
	{
		//Objeto primeira carta defini como vazio
		firstCard = null;

		//Objeto segunda carta defini como vazio
		secondCard = null;

		//Variavel para poder virar carta é definido como verdadeiro
		canFlip = true;
	}
}
