using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Dto.OrderDetailDtos
{
    public class CreateOrderDetailDto
    {
        private int _productId;

        public int ProductId
        {
            get => _productId;
            set
            {
                _productId = value;
                SetTitle(); 
            }
        }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public string Title { get; private set; }
        private readonly Guid OrderGuid = Guid.NewGuid();
        private void SetTitle()
        {
            Title = $"Order_{ProductId}_{OrderGuid.ToString("N")[..10]}";
        }
    }

}
