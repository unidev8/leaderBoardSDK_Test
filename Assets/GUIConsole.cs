
using UnityEngine;
using System.Collections.Generic;

struct LogEntry
{
    public string message;
    public LogType type;

    public LogEntry(string message, LogType type)
    {
        this.message = message;
        this.type = type;
    }
}

public class GUIConsole : MonoBehaviour
{
    public int height = 150;
   
    public int maxLogCount = 50;

    Queue<LogEntry> log = new Queue<LogEntry>();

    public KeyCode hotKey = KeyCode.F12;

    // GUI
    bool visible;
    Vector2 scroll = Vector2.zero;

    void Awake()
    {
        Application.logMessageReceived += OnLog;
    }

    
    void OnLog(string message, string stackTrace, LogType type)
    {

        bool isImportant = type == LogType.Error || type == LogType.Exception || type == LogType.Warning;

        if (isImportant && !string.IsNullOrWhiteSpace(stackTrace))
            message += $"\n{stackTrace}";

        // add to queue
        log.Enqueue(new LogEntry(message, type));

        // respect max entries
        if (log.Count > maxLogCount)
            log.Dequeue();

        // become visible if it was important
        // (no need to become visible for regular log. let the user decide.)
        if (isImportant)
            visible = true;

        // auto scroll
        scroll.y = float.MaxValue;
    }

    void Update()
    {
        //if (Input.GetKeyDown(hotKey))
            //visible = !visible;
    }

    void OnGUI()
    {
        //if (!visible) return;

        scroll = GUILayout.BeginScrollView(scroll, "Box", GUILayout.Width(Screen.width), GUILayout.Height(height));
        foreach (LogEntry entry in log)
        {
            if (entry.type == LogType.Error || entry.type == LogType.Exception)
                GUI.color = Color.red;
            else if (entry.type == LogType.Warning)
                GUI.color = Color.yellow;

            GUILayout.Label(entry.message);
            GUI.color = Color.white;
        }
        GUILayout.EndScrollView();
    }
}