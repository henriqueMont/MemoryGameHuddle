using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo controla as ações e eventos da carta no jogo da memoria
//Linguagem C#
//Ultima revisão: 17/10/2018

public class cardController : MonoBehaviour {

	//Declaração da variavel que coleta o nome da carta 
	//O SerializeField mostra no Inspector mesmo sendo variavel privada 
	[SerializeField]
	private string cardName;

	//Verifica se carta esta virada para baixo
	private bool isFaceSide = false;

	//Armazena a imagem de carta virada para baixo
	private Sprite backSideCardSprite;

	//Armazena a imagem de carta virada para cima
	[SerializeField]
	private Sprite frontSideCardSprite;

	//Declara o renderizador de sprites para fazer a troca das sprites
	private SpriteRenderer spriteRenderer;

	//Declara o objeto gameManager para poder ser usado no codigo
	private gameManager gameManager;

	//Declara o controlador das animações do objeto
	private Animator animator;

	//Executa está função quando a cena é inicia
	void Start () 
	{
		//Instancia o renderizador
		spriteRenderer = GetComponent<SpriteRenderer> ();

		//Define qual sera a sprite para carta virada para baixo
		backSideCardSprite = spriteRenderer.sprite;

		//Procura o objeto gameManager e instancia
		gameManager = FindObjectOfType<gameManager> ();

		//Pega o componente de controle de animações e instancia
		animator = GetComponent<Animator> ();

		//Inicia uma coroutina, de inicio de jogo
		StartCoroutine (StartMemory());

	}

	//Metodo para acessar a variavel privada de cardName
	public string CardName
	{
		//Pega o cardName e retorna para o metodo
		get{return cardName; }
		//Colocar e atualiza o valor de cardName
		set{cardName = value; }
	}

	//Função que é executada quando o botao do mouse é pressionado
	private void OnMouseDown()
	{
		///Verifica se ele pode virar a carta
		if (gameManager.CanFlip == true && isFaceSide == false) 
		{
			//Envia o objeto carta para o gameManager
			gameManager.AddCard (gameObject);

			//Chama a funcão para virar carta
			ChangeSide ();
		}
	}

	//Função que vira a carta
	public void ChangeSide()
	{
		//Verifica se a carta não esta virada com a frente, ela irá virar para frente
		if(isFaceSide == false)
		{
			//Manda o renderizador trocar a sprite para a da frente
			spriteRenderer.sprite = frontSideCardSprite;

			//Atualiza a variavel, passando que esta para frente
			isFaceSide = true;

			//Executa um gatilho para animação de virando a carta
			animator.SetTrigger("Act");
		} 
		//Se está virada para frente, ela vira para trás
		else
		{
			//Executa um gatilho para animação de virando a carta
			animator.SetTrigger("Act");

			//Manda o renderizador trocar a sprite para a de trás
			spriteRenderer.sprite = backSideCardSprite;

			//Atualiza a variavel, passando que não esta para frente
			isFaceSide = false;
		}
	}

	//Coroutina de inicio da fase, para fazer todas as cartas ficarem com a frente por um tempo e depois voltar com a de trás
	IEnumerator StartMemory()
	{
		//Espera alguns segundos antes de virar as cartas para frente
		yield return new WaitForSeconds (0.5f);

		//Vira as cartas para frente
		ChangeSide ();

		//Espera alguns segundo antes de virar as cartas para trás novamento
		yield return new WaitForSeconds (2f);

		//Vira as cartas para trás
		ChangeSide ();
	}

}
