public async Task<Contact> Create(Contact contact)
{
    if (string.IsNullOrWhiteSpace(contact.Name))
    {
        throw new ArgumentException("Name is required.");
    }
    
    HttpResponseMessage response = await client.PostAsJsonAsync("611edbd7fd5915f2ae005dc2", contact);
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsAsync<Contact>();
}
