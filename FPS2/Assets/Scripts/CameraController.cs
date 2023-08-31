using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float tempoPiscar = 0.2f; // Duração do efeito de piscar em vermelho
    public Color corPiscar = Color.red; // Cor do efeito de piscar em vermelho

    private bool piscando = false; // Verifica se a câmera está piscando
    private Color corOriginal; // Cor original da câmera

    private void Start()
    {
        corOriginal = GetComponent<Camera>().backgroundColor;
    }

    public void PiscarVermelho()
    {
        if (!piscando)
        {
            StartCoroutine(PiscarVermelhoCoroutine());
        }
    }

    private IEnumerator PiscarVermelhoCoroutine()
    {
        piscando = true;

        GetComponent<Camera>().backgroundColor = corPiscar;

        yield return new WaitForSeconds(tempoPiscar);

        GetComponent<Camera>().backgroundColor = corOriginal;
        piscando = false;
    }
}