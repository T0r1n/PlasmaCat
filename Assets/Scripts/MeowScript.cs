using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowScript : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public AudioSource Meows;


    public void PlayRandomSound()
    {
        // Создаем массив из двух звуков
        AudioClip[] sounds = new AudioClip[] { sound1, sound2 };

        // Выбираем случайный индекс
        int randomIndex = UnityEngine.Random.Range(0, sounds.Length);

        // Назначаем выбранный звук AudioSource и воспроизводим
        Meows.clip = sounds[randomIndex];
        Meows.Play();
    }
}
