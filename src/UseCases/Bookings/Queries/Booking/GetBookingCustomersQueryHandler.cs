namespace Application.Bookings.Queries.Booking;

internal class GetBookingCustomersQueryHandler(IApplicationDbContext _context) : IQueryHandler<GetBookingCustomersQuery, GetBookingCustomersResult>
{
    public async Task<GetBookingCustomersResult> Handle(GetBookingCustomersQuery request, CancellationToken cancellationToken)
    {
        var customerItems = await _context.Customers
            .Where(customer => customer.Sub == request.Sub)
            .Select(customer => new BookingCustomerItemDto
            {
                CustomerId = customer.Id.Value.ToString(),
                Name = customer.Name
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new GetBookingCustomersResult(customerItems);
    }
}
