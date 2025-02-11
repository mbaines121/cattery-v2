using BuildingBlocks.Exceptions;

namespace Application.Exceptions;

public class CustomerNotFoundException : NotFoundException
{
    public CustomerNotFoundException(CustomerId id) : base("Customer", id)
    {
    }
}
