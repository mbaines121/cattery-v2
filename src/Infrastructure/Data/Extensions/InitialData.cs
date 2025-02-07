namespace Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Pen> Pens
    {
        get
        {
            var pen = Pen.Create(PenId.Of(Guid.Parse("06a725ab-be4d-494b-95e4-7fc4af1e8e0c")), "Pen 1");

            return new List<Pen> { pen };
        }
    }

    public static IEnumerable<Customer> Customers
    {
        get
        {
            var customer = Customer.Create(CustomerId.Of(Guid.Parse("d9296bc7-73f8-4cc6-93b9-6c4ea1bc5dd9")), "John Smith", "john.smith@test.com");

            var address = Address.Of("1 Some Street", "Some area", "Some town", "North Yorkshire", "DL1 1AB");
            customer.SetAddress(address);

            var animal = customer.AddAnimal(AnimalId.Of(Guid.Parse("2d96756f-cc47-46b9-ba9b-5afdd1b518ce")), "Aslan");

            return new List<Customer>
            {
                customer
            };
        }
    }

    public static IEnumerable<Booking> Bookings
    {
        get
        {
            // Here we are creating the BookedCustomer and BookenPen entities in the Booking aggregate - so we don't need to set all properties, but only the properties that apply to this aggregate.

            // customer
            var customer = Customers.First();
            var booking = Booking.Create(BookingId.Of(Guid.Parse("fe3568a2-da63-4aa8-b308-62517d846476")));
            booking.AddBookedCustomer(customer.Id, customer.Name);

            // pen
            var pen = Pens.First();
            var bookedPen = booking.AddBookedPen(pen.Id, pen.Name, DateTime.UtcNow.AddDays(-5), DateTime.Now.AddDays(5));

            // animal
            var animal = customer.OwnedAnimals.First();
            bookedPen.AddBoardedAnimal(animal.Id, animal.Name);

            return new List<Booking>
            {
                booking
            };
        }
    }
}
