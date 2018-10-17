using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo controla as ações do Tempo do jogo
//Linguagem C#
//Ultima revisão: 17/10/2018

public class timeCounter : MonoBehaviour {
	
	//Tempo contado
	private float timeCount = 0.0f;

	//Declara o objeto de texto para mostrar o tempo do jogo
	//O SerializeField mostra no Inspector mesmo sendo variavel privada
	[SerializeField]
	private Text timeText;

	//Declara e defini um contador
	private int counter = 1;

	//Declara e defini o valor inicial do contador
	private int startCount = 60;

	//Declara e define que o jogo começou e pode ser feito a contagem
	private bool countTime = true;

	//Metodo para acessar a variavel privada de countTime
	public bool CountTime
	{
		//Pega o countTime e retorna para o metodo
		get{return countTime; }

		//Coloca e atualiza o valor de countTime
		set{countTime = value;}
	}

	//Metodo para acessar a variavel privada de timeCounted
	public int timeCounted
	{
		//Pega o tempo inicial, startCount e subtrai o contado counter e retorna para o metodo
		get{return (startCount - counter); }
	}

	//Executa está função a cada frame da cena
	void Update () 
	{
		//Verifica se pode fazer a contagem
		//Se sim
		if (countTime) 
		{
			//Verifica se o valor do tempo contado é maior ou igual a o contado counter
			//Se sim
			if (timeCount >= counter) 
			{
				//Manda o texto de tempo atualizar qual o valor do tempo, sera o valor inicial contador menos o contado
				timeText.text = "Time: " + (startCount-counter);

				//adiciona +1 ao contador
				counter++;
			}

			//Tempo contado é somado a cada diferença de tempo pelo tempo
			timeCount += Time.deltaTime;
		}
	}
}
