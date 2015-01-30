﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	private static bool IsGamingOver = false;
	public static Timer timer;
	public static SceneBlender blender;
	public static SoundManager sound;
	public static Door door;
	public static List<Item> items;
    public static Points points;
    public static Config config;

    void Awake()
    {
		timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
		items = new List<Item>();
		foreach(Item item in Component.FindObjectsOfType<Item>())
			items.Add(item);
        points = GameObject.FindGameObjectWithTag("PointContainer").GetComponent<Points>();
        config = GameObject.FindGameObjectWithTag("Container").GetComponent<Config>();
    }

    // Use this for initialization
    void Start()
    {
        blender = SceneBlender.Instance;
        sound = SoundManager.Instance;

        if (points != null)
        {
            points.ChangeGUI();
        }
	}
	
	public static void SetGameOver()
	{
		if(!IsGamingOver)
		{
			timer.StopTimerCounting();
			IsGamingOver = true;
			sound.Play("Derp_sad", 1.0f);
			blender.FadeToScene("gameover");
		}
	}

	public static void SetGameWin()
	{
		timer.StopTimerCounting();
		sound.Play("Derp_happy", 1.0f);
		timer.TransfareToPoints();
		blender.FadeToScene("winscreen");
	}

	public static void SetNextLevel()
	{
		timer.StopTimerCounting();
		sound.Play("Derp_happy", 1.0f);
		timer.TransfareToPoints();
		blender.FadeNextScene();
	}



}
