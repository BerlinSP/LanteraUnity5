using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lampada : MonoBehaviour {

    /*
        Simples Sistema de Lantenar...
        Atenção esse script é apenas para estudos.
        O Objetivo é mostrar como pode ser criado um sistema de lanterna.
    */

    Light lampadaLanterna;

    public Text textBateria;
    public Text textRecarga;
    public Text texttempoConsumo;
    public Slider tempoConsumo;
    public Slider addQuantidade;
    public Scrollbar scrollCarga;

    [SerializeField][Range(10, 60)]
    private float tempo;
    private float tempoGet;
    private float bateriaLanterna;
    private int quantidadeCarga;

    private void Start()
    {
        lampadaLanterna = GetComponent<Light>();
    }

    private void Update()
    {
        tempoGet -= Time.deltaTime;

        textRecarga.text = "" + quantidadeCarga + "%";
        texttempoConsumo.text = "Consumir a cada " + Mathf.FloorToInt(tempo) + " Seg";
        textBateria.text = "Carga Bateria : " + bateriaLanterna + "%";

        tempo = tempoConsumo.value;
        quantidadeCarga = Mathf.FloorToInt(addQuantidade.value);

        scrollCarga.size = bateriaLanterna / 100;
        lampadaLanterna.range = bateriaLanterna;

        if (tempoGet <= 0)
        {
            bateriaLanterna -= 10;
            tempoGet = tempo;
        }

        if (bateriaLanterna <= 0)
            bateriaLanterna = 0;
    }

    public void SetBateria()
    {
        bateriaLanterna = quantidadeCarga;
    }

}

