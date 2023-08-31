using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public Color flashColor = new Color(1f, 0f, 0f, 0.5f); // Vermelho semi-transparente
    public float flashDuration = 0.2f; // Duração do piscar em segundos

    private Color originalColor;
    private bool isFlashing = false;

    private void Start()
    {
        originalColor = flashImage.color;
        flashImage.gameObject.SetActive(false);
    }

    public void Flash()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashRoutine());
        }
    }

    private IEnumerator FlashRoutine()
    {
        isFlashing = true;
        flashImage.gameObject.SetActive(true);
        flashImage.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        flashImage.color = originalColor;
        flashImage.gameObject.SetActive(false);
        isFlashing = false;
    }
}