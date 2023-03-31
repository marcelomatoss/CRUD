public class ContactRepository
{
    private HttpClient client;
    
    public ContactRepository(HttpClient httpClient)
    {
        client = httpClient;
    }
    
    public async Task<Contact> Create(Contact contact)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("611edbd7fd5915f2ae005dc2", contact);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Contact>();
    }
    
    public async Task<Contact> GetById(string id)
    {
        HttpResponseMessage response = await client.GetAsync($"611edbd7fd5915f2ae005dc2/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Contact>();
    }
    
    public async Task<Contact> Update(string id, Contact contact)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync($"611edbd7fd5915f2ae005dc2/{id}", contact);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Contact>();
    }
    
    public async Task<bool> Delete(string id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"611edbd7fd5915f2ae005dc2/{id}");
        response.EnsureSuccessStatusCode();
        return response.IsSuccessStatusCode;
    }
}
