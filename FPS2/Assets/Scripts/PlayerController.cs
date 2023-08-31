using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int HP = 100; // Pontos de vida do jogador
    public Image damageImage = null;
    public GameObject deathObject = null; // Objeto que contém a imagem de morte
    private float hurtTimer = 0.5f;
    private float fadeDuration = 0.3f; // Duração de cada etapa de fade
    private bool deathObjectActive = false;

    private void Start()
    {
        damageImage.enabled = false;
        deathObject.SetActive(false); // Certifica-se de que o objeto esteja desativado no início
    }

    public void TakeDamage(int damageAmountE)
    {
        HP -= damageAmountE;
        if (HP <= 0)
        {
            DeathFlash();
        }
        else
        {
            StartCoroutine(HurtFlash());
        }
    }

    IEnumerator HurtFlash()
    {
        damageImage.enabled = true;
        
        // Etapa de Fade In
        Color originalColor = damageImage.color;
        Color fadeInColor = originalColor;
        fadeInColor.a = 0.3f; // Define o canal alpha para 0.3 (parcialmente opaco)

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            damageImage.color = Color.Lerp(originalColor, fadeInColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        damageImage.color = fadeInColor; // Certifica-se de que a imagem esteja parcialmente opaca

        // Espera
        yield return new WaitForSeconds(hurtTimer);

        // Etapa de Fade Out
        elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            damageImage.color = Color.Lerp(fadeInColor, originalColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        damageImage.color = originalColor; // Certifica-se de que a imagem esteja totalmente transparente
        damageImage.enabled = false;
    }

    void DeathFlash()
    {
        deathObject.SetActive(true);
        deathObjectActive = true;
        // Etapa de espera
        //yield return new WaitForSeconds(hurtTimer); // Ajuste conforme necessário

        //deathObject.SetActive(false);
    }

    void Update()
    {
        if(deathObjectActive && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)))
        {
            SceneManager.LoadScene(0);
        }
    }
}