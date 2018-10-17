using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.IO;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo é o responsavel pelo controle da pontuação do jogo
//Linguagem: C#
//Ultima revisão: 17/10/2018

public class cardSpawner : MonoBehaviour {

	//Declara a lista de objetos carta que vão ser spawnadas na cena
	//O SerializeField mostra no Inspector mesmo sendo variavel privada
	[SerializeField]
	private List<GameObject> cardsToSpawn;

	//Declara a lista com o numero de cartas que vão ser spawnadas
	[SerializeField]
	private List<int> cardsToSpawnCount;

	//Declara a posição inicial para spawnar os objetos carta
	[SerializeField]
	private Transform startPoint;

	//numero de linhas de cartas que terá no jogo, referencia para o sistema spawnar
	[SerializeField]
	private int rows = 2;  

	//numero de colunas de cartas que terá no jogo, referencia para o sistema spawnar
	[SerializeField]
	private int columns = 4;  

	//Distancia entre cada coluna de cartas que terá no jogo, referencia para o sistema spawnar
	[SerializeField]
	private int xDistance = 4; 

	//Distancia entre cada linha de cartas que terá no jogo, referencia para o sistema spawnar
	[SerializeField]
	private int yDistance = 4;

	//Declara o objeto gameManager que será usado neste codigo
	private gameManager gameManager; 



	void Start () 
	{
		//Instanciando o objeto gameManager a variavel
		gameManager = FindObjectOfType<gameManager> (); 

		//Chamado da função Spawn para que ela crie as cartas do jogo
		Spawn ();   

		//gameObject.SetActive (false);
	}

	void Spawn()
	{
		//Declara o numero da carta, usado no jogo
		int cardNumber;  

		//Calcula o numero limite de cartas no jogo
		int maxCards = rows * columns; 

		//Verifica se o maxCards dividido por 2 se é igual a 0
		//Se sim
		if (maxCards % 2 == 0) 
		{
			//Defini e cria uma lista da conta de cartas que devem ser spawnadas
			cardsToSpawnCount = new List<int> ();

			//Pega o total de cartas no gameManager e aloca o valor em maxCards
			gameManager.CardsTotal = maxCards;

			//Aloca em cada posição da lista, um cardToSpawnCount o valor de i
			for (int i = 0; i < cardsToSpawn.Count; i++) 
			{
				cardsToSpawnCount.Add (i);
			}

			//Aloca em cada posição da lista, ou seja em cada cardToSpawnCount o valor maximo de duas cartas para serem spawnadas
			for (int i = 0; i < cardsToSpawnCount.Count; i++) 
			{
				//Adiciona o valor maximo de duas cartas por cardsToSpawnCount
				cardsToSpawnCount [i] = 2; 
			}

			//Defini um valor indice para posição em y, 
			for (int i = 0; i < rows; i++) 
			{
				//Defini um valor indice para a posição em y
				for (int j = 0; j < columns; j++) 
				{
					//Executa enquanto o break não for acionado, o brake defini que está carta pode ser instanciada na poisição, sem que haja sobrecarta na mesma posição e que não haja mais de duas cartas da repetidas
					for (int z = 0; z < 100; z++) 
					{
						//cardNumber recebe um valor aleatorio entre 0 e o valor do tamanho do "vetor/lista" de cardsToSpawnCount
						cardNumber = Random.Range(0,cardsToSpawnCount.Count);

						//Verifica se essa carta foi espawnada menos de duas vezes
						//Se sim
						if (cardsToSpawnCount [cardNumber] > 0) 
						{
							//Instancia/Cria a carta do cardsToSpawn, na posição indicadas pelos indices de i e j 
							Instantiate (cardsToSpawn [cardNumber], new Vector3 (startPoint.position.x + xDistance * j, startPoint.position.y - yDistance * i, startPoint.position.z), Quaternion.Euler (0.0f, 0.0f, 0.0f));

							//Subtrai das carta que foi spawnada para que não haja mais de duas cartas na cena
							cardsToSpawnCount [cardNumber]--;

							//Para o for, para que spawne as cartas em outras posições
							break;
						} else 
						{
							//Este else deve ser usado para garantir que os valores serão colocados e spawnados corretamente 
						}
					}

				}
			}
		}
		//Se não
		else
		{
		}

	}
}
