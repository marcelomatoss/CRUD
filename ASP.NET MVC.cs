public class ContactController : Controller
{
    private ContactRepository repository;
    
    public ContactController(ContactRepository contactRepository)
    {
        repository = contactRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        List<Contact> contacts = new List<Contact>();
        
        // Retrieve all contacts from the API
        HttpResponseMessage response = await repository.client.GetAsync("611edbd7fd5915f2ae005dc2");
        response.EnsureSuccessStatusCode();
        contacts = await response.Content.ReadAsAsync<List<Contact>>();
        
        return View(contacts);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            await repository.Create(contact);
            return RedirectToAction("Index");
