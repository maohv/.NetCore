using Microsoft.AspNetCore.Mvc.RazorPages;

public class ContactRequestModel : PageModel
{
    public string UserId { get; set; } = "Hoang Mao";

    private readonly ILogger<ContactRequestModel> _logger;

    public ContactRequestModel(ILogger<ContactRequestModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("Init contact...");

        Console.WriteLine("Init Contact");
    }

    public double Tong(double a, double b)
    {
        return a + b;
    }
}