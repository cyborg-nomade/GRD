using CPTM.GRD.Domain.AccessControl;

namespace CPTM.GRD.Application.Models;

public class EmailSettings
{
    public User Sender { get; set; } = new User();
}