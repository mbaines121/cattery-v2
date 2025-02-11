namespace Application.Bookings.Queries.Booking;

internal class GetBookingCustomersQueryHandler(IApplicationDbContext _context) : IQueryHandler<GetBookingCustomersQuery, GetBookingCustomersResult>
{
    public async Task<GetBookingCustomersResult> Handle(GetBookingCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _context.Customers.ToListAsync(cancellationToken);

        var customerItems = customers
            .Select(customer => new BookingCustomerItemDto
            {
                CustomerId = customer.Id.Value.ToString(),
                Name = customer.Name
            });

        return new GetBookingCustomersResult(customerItems);
    }
}
