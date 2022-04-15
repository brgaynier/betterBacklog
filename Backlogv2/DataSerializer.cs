using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class DataSerializer
{

public void JsonSerialize(object data, string filePath)
{
    JsonSerializer jsonSerializer = new JsonSerializer();
    if(File.Exists(filePath)) File.Delete(filePath);
    StreamWriter sw = new StreamWriter(filePath);
    JsonWriter jsonWriter = new JsonTextWriter(sw);

    jsonSerializer.Serialize(jsonWriter, data);

    jsonWriter.Close();
    sw.Close();
}


public object? JsonDeserialize(Type dataType, string filePath)
{
    object? obj = null;

    JsonSerializer jsonSerializer = new JsonSerializer();
    if(File.Exists(filePath))
    {
        // StreamReader sr = new StreamReader(filePath);
        using StreamReader sr =  File.OpenText(filePath);
        using JsonReader jsonReader = new JsonTextReader(sr);
        obj = jsonSerializer.Deserialize(jsonReader,dataType);
        jsonReader.Close();
        sr.Close();

    }
    
    return obj;

}



}


