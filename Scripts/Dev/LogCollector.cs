using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class LogCollector
{
    public static int Capacity { get; private set; }
    public static bool IsInitialized { get; private set; }

    private static int _index = -1;
    private static LogRecord[] _records;
        
    #region -- Record --
    public struct LogRecord
    {
        public string message;
        public LogType type;

        public LogRecord(string message, LogType type)
        {
            this.message = message;
            this.type = type;
        }

        public override string ToString()
        {
            return $"{type}: {message}";
        }

        public bool Equals(LogRecord other)
        {
            return string.Equals(message, other.message) && type == other.type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LogRecord && Equals((LogRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((message != null ? message.GetHashCode() : 0) * 397) ^ (int) type;
            }
        }
    }
    #endregion
    
    public static void Init(int capacity = 1024)
    {
        if (capacity > Capacity)
        {
            Capacity = capacity;
            _records = new LogRecord[capacity];
        }
        if (IsInitialized) return;
        IsInitialized = true;
        Application.logMessageReceivedThreaded += OnLog;
    }

    private static void OnLog(string condition, string stacktrace, LogType type)
    {
        lock (_records)
        {
            _index = (_index + 1) % Capacity;
            _records[_index].message = condition;
            _records[_index].type = type;
        }
    }

    public static string GetLogString() => string.Join("\n", CollectLogs());
        
    public static List<LogRecord> CollectLogs()
    {
        List<LogRecord> logs;
        int count;
        int start;
        lock (_records)
        {
            logs = _records.ToList();
            count = Math.Max(0, Math.Min(_index + 1, Capacity));
            start = _index < Capacity ? 0 : _index + 1;
        }

        var retval = new List<LogRecord>();
        for (var i = 0; i < count; i++)
        {
            var i1 = (start + i) % Capacity;
            retval.Add(logs[i1]);
        }

        return retval;
    }
}