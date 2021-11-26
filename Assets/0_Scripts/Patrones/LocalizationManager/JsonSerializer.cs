using System.Collections.Generic;
using System.IO;
using MiniJSON;

public static class JsonSerializer {

    public static void SaveJson<T>(this T obj, string absolutePath) {
        var json = Json.Serialize(obj);
        File.WriteAllText(absolutePath, json);
    }

    public static Dictionary<string, object> LoadJson(string absolutePath) {
        var text = File.ReadAllText(absolutePath);
        
        return (Dictionary<string, object>)Json.Deserialize(text);
    }
    
}