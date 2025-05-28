using System.Text.Json.Serialization;
using Gadgets.Common.Contracts;
using Newtonsoft.Json;

namespace Gadgets.Common.Services;

public abstract class CrudService<T> : ICrudService<T>
{
    protected Dictionary<Guid, T> _values = new();
    
    public void Create(T element)
    {
        _values.Add(GetId(element), element);
    }

    public T Read(Guid id)
    {
        return _values[id];
    }

    public IEnumerable<T> ReadAll()
    {
        return _values.Values;
    }

    public void Update(T element)
    {
        _values[GetId(element)] = element;
    }

    public void Remove(T element)
    {
        _values.Remove(GetId(element));
    }

    public void Load(string path)
    {
        try
        {
            _values = JsonConvert.DeserializeObject<Dictionary<Guid, T>>(File.ReadAllText(path))!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Save(string path)
    {
        try
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(_values, Formatting.Indented));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    protected abstract Guid GetId(T element);
}