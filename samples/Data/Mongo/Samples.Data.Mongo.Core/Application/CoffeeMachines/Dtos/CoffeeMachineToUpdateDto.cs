namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos
{
    public class CoffeeMachineToUpdateDto
    {
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
