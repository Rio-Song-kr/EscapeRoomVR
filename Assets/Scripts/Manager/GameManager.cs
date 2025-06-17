using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public AudioManager Audio { get; private set; }

    public static void CreateInstance()
    {
        if (_instance == null)
        {
            var gameManagerPrefab = Resources.Load<GameManager>("GameManager");
            _instance = Instantiate(gameManagerPrefab);
            DontDestroyOnLoad(_instance);
        }
    }

    public static void ReleaseInstance()
    {
        if (_instance != null)
        {
            Destroy(_instance);
            _instance = null;
        }
    }

    private void Awake()
    {
        Audio = GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

}