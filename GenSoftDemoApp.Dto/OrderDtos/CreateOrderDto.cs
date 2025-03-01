using GenSoftDemoApp.Dto.OrderDetailDtos;
using System.Text.Json.Serialization;

namespace GenSoftDemoApp.Dto.OrderDtos
{
    public class CreateOrderDto
    {
        private int _userId;

        public decimal TotalPrice { get; set; }
        public int UserId
        {
            get => _userId;
            set
            {
                if (_userId == 0)
                {
                    _userId = value;
                    GenerateOrderNumber();
                    SetTitle();
                }
            }
        }

        public List<CreateOrderDetailDto>? OrderDetails { get; set; }
        [JsonIgnore]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [JsonIgnore]
        public string Title { get; private set; }

        [JsonIgnore]
        public string OrderNumber { get; private set; }
        public string? IpAddress { get; set; }
        public string? FullName { get; set; }
        public string? CompanyName { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Mail { get; set; }
        public string? Notes { get; set; }
        private readonly Guid OrderGuid = Guid.NewGuid();
        private void GenerateOrderNumber()
        {
            string prefix = "GEN";
            string userIdPart = UserId.ToString().PadLeft(4, '0'); // UserId'yi en az 4 karakter yap
            string orderPart = OrderGuid.ToString("N")[..10]; // GUID'in ilk 10 karakteri

            OrderNumber = $"{prefix}_{userIdPart}_{orderPart}";
        }


        private void SetTitle()
        {
            Title = $"Order_{UserId}_{OrderGuid}";
        }
    }


}
