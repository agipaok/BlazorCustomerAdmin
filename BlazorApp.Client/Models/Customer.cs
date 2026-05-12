using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Client.Models;

public class Customer
{
    public string? Id { get; set; }
    [Required(ErrorMessage = "Το όνομα της εταιρείας είναι υποχρεωτικό")]
    public string CompanyName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Το όνομα επαφής είναι υποχρεωτικό")]
    public string ContactName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Η διεύθυνση είναι υποχρεωτική")]
    public string Address { get; set; } = string.Empty;
    [Required(ErrorMessage = "Η πόλη είναι υποχρεωτική")]
    public string City { get; set; } = string.Empty;
    public string? Region { get; set; }
    [Required(ErrorMessage = "Ο ταχυδρομικός κώδικας είναι υποχρεωτικός")]
    [RegularExpression(@"^\d{5}$", ErrorMessage = "Ο ΤΚ πρέπει να αποτελείται από ακριβώς 5 ψηφία")]
    public string PostalCode { get; set; } = string.Empty;
    [Required(ErrorMessage = "Η χώρα είναι υποχρεωτική")]
    public string Country { get; set; } = string.Empty;
    [Required(ErrorMessage = "Το τηλέφωνο είναι υποχρεωτικό")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Το τηλέφωνο πρέπει να αποτελείται από ακριβώς 10 ψηφία")]
    public string Phone { get; set; } = string.Empty;
}