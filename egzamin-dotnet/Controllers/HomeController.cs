using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    readonly Laczenie skrypty;
    private List<Wycieczki> skrypt2;

    public HomeController(IConfiguration configuration) => skrypty = new Laczenie(configuration);
    
    public IActionResult Index()
    {

        skrypt2 = skrypty.Skrypt2("SELECT cel, dataWyjazdu FROM wycieczki WHERE dostepna = 0;");
        ViewBag.wycieczki = skrypt2;
        
        var skrypt1 = skrypty.Skrypt1();
        return View(skrypt1);
    }
    
    [HttpPost]
    public IActionResult Index(string check)
    {

        if (check == "on")
        {
            skrypt2 = skrypty.Skrypt2("SELECT cel, dataWyjazdu FROM wycieczki WHERE dostepna = 1;");
        }
        else
        {
            skrypt2 = skrypty.Skrypt2("SELECT cel, dataWyjazdu FROM wycieczki WHERE dostepna = 0;");
        }
        
        ViewBag.wycieczki = skrypt2;
        var skrypt1 = skrypty.Skrypt1(); // Assuming Skrypt1() fetches the images
        return View(skrypt1);
    }
}