using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class PresetManager
{
    private string filePath;

    public PresetManager(string path)
    {
        filePath = path;
    }

    public void SavePreset(string presetName, object presetData)
    {
        var presets = LoadPresets();
        presets[presetName] = presetData;
        File.WriteAllText(filePath, JsonConvert.SerializeObject(presets, Formatting.Indented));
    }

    public object LoadPreset(string presetName)
    {
        var presets = LoadPresets();
        presets.TryGetValue(presetName, out var presetData);
        return presetData;
    }

    private Dictionary<string, object> LoadPresets()
    {
        if (!File.Exists(filePath))
        {
            return new Dictionary<string, object>();
        }

        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
    }
}