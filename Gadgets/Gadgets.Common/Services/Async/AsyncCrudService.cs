using System.Collections;
using System.Collections.Concurrent;
using Gadgets.Common.Contracts;
using Newtonsoft.Json;

namespace Gadgets.Common.Services.Async;

public abstract class AsyncCrudService<T> : IAsyncCrudService<T>
{
    protected ConcurrentDictionary<Guid, T> _values = new();
    protected SemaphoreSlim _semaphore = new(1);
    
    public IEnumerator<T> GetEnumerator()
    {
        return _values.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public async Task<bool> CreateAsync(T element)
    {
        return _values.TryAdd(GetId(element), element);
    }

    public async Task<T> ReadAsync(Guid id)
    {
        _values.TryGetValue(id, out var value);
        return value;
    }

    public async Task<IEnumerable<T>> ReadAllAsync()
    {
        return _values.Values;
    }

    public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        return _values.Values.Skip(amount * page).Take(amount);
    }

    public async Task<bool> UpdateAsync(T element)
    {
        return _values.TryUpdate(GetId(element), element, element);
    }

    public async Task<bool> RemoveAsync(T element)
    {
        return _values.TryRemove(GetId(element), out _);
    }

    public async Task Load(string path)
    {
        try
        {
            await _semaphore.WaitAsync();
            _values = JsonConvert.DeserializeObject<ConcurrentDictionary<Guid, T>>(File.ReadAllText(path))!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task Save(string path)
    {
        try
        {
            await _semaphore.WaitAsync();
            File.WriteAllText(path, JsonConvert.SerializeObject(_values, Formatting.Indented));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    protected abstract Guid GetId(T element);
}