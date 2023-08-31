using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform jogador; // Referência ao transform do jogador
    public float distânciaVisão = 10f; // Distância em que o jogador é visto
    public float distânciaSegura = 2f; // Distância segura entre o inimigo e o jogador
    public float velocidadePerseguição = 5f; // Velocidade de perseguição do inimigo
    public float ânguloVisão = 90f; // Ângulo de visão do inimigo

    public Transform[] pontosPatrulha; // Pontos de patrulha no mapa
    public float intervaloPatrulha = 5f; // Intervalo de tempo entre as mudanças de patrulha
    private int pontoAtual = 0; // Índice do ponto de patrulha atual

    private bool jogadorÀVista = false; // Verifica se o jogador está à vista
    private Animator animador; // Referência ao componente Animator
    private NavMeshAgent navMeshAgent; // Referência ao componente NavMeshAgent

    private static readonly int CorrerHash = Animator.StringToHash("Crawling"); // Hash da variável "Correr" no Animator

    private void Start()
    {
        // Obter as referências aos componentes Animator e NavMeshAgent
        animador = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Iniciar a patrulha
        if (pontosPatrulha.Length > 0)
        {
            InvokeRepeating("Patrulhar", 0f, intervaloPatrulha);
        }
    }

    private void Update()
    {
        // Verificar a distância entre o inimigo e o jogador
        float distância = Vector3.Distance(transform.position, jogador.position);

        // Verificar se o jogador está à vista com base na distância e no ângulo de visão
        if (distância <= distânciaVisão && VerificarVisão())
        {
            jogadorÀVista = true;
        }
        else
        {
            jogadorÀVista = false;
        }

        // Se o jogador estiver à vista, perseguir o jogador usando o NavMeshAgent
        if (jogadorÀVista)
        {
            // Cancelar a patrulha se o jogador estiver à vista
            CancelInvoke("Patrulhar");

            // Ativar a animação de correr
            animador.SetBool(CorrerHash, true);

            // Calcular a direção para o jogador
            Vector3 direção = jogador.position - transform.position;
            direção.y = 0f; // Ignorar a componente y para manter o inimigo no mesmo plano

            // Atualizar a rotação do inimigo para encarar o jogador
            transform.rotation = Quaternion.LookRotation(direção);

            // Definir o destino do NavMeshAgent como a posição do jogador
            navMeshAgent.SetDestination(jogador.position);
        }
        else
        {
            // Se o jogador não estiver à vista, continuar a patrulha
            if (!IsInvoking("Patrulhar"))
            {
                InvokeRepeating("Patrulhar", 0f, intervaloPatrulha);
            }

            // Desativar a animação de correr
            animador.SetBool(CorrerHash, false);
        }

        // Verificar se o inimigo chegou ao destino de patrulha
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            // Atualizar o próximo ponto de patrulha
            pontoAtual = (pontoAtual + 1) % pontosPatrulha.Length;

            // Definir o próximo destino do NavMeshAgent como o próximo ponto de patrulha
            navMeshAgent.SetDestination(pontosPatrulha[pontoAtual].position);
        }
    }

    private void Patrulhar()
    {
        // Definir o destino do NavMeshAgent como o ponto de patrulha atual
        navMeshAgent.SetDestination(pontosPatrulha[pontoAtual].position);
    }

    private bool VerificarVisão()
    {
        // Calcular a direção para o jogador
        Vector3 direção = jogador.position - transform.position;
        direção.y = 0f; // Ignorar a componente y para manter o inimigo no mesmo plano

        // Calcular o ângulo entre a direção do inimigo e a frente do inimigo em relação ao jogador
        float ângulo = Vector3.Angle(direção, transform.forward);

        // Verificar se o ângulo está dentro do alcance de visão especificado
        if (ângulo <= ânguloVisão * 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}