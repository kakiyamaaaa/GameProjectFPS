using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    public GameObject hud;
    public GameObject inv;
    public GameObject deathScreen;
    public GameObject player;

    public float health = 100f;



    void Start()
    {
        deathScreen.SetActive(false);
    }
    
    public void ReduzirVida(int quantidade)
{
    health -= quantidade;
    // Faça aqui qualquer ação adicional necessária, como verificar se o jogador morreu ou atualizar a interface do usuário.
}



    void Update()
    {

        if(health <= 0)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hud.SetActive(false);
            inv.SetActive(false);
            deathScreen.SetActive(true);
        }

        if (health > 100)
        {
            health = 100;
        }
        
    }
}
