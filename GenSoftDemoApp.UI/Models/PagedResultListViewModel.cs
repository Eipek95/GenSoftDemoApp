namespace GemSoftDemoApp.UI.Models
{
    public class PagedResultListViewModel<T>
    {
        public IEnumerable<T> Data { get; set; } // Sayfalandırılmış veri
        public int CurrentPage { get; set; } // Mevcut sayfa
        public int PageSize { get; set; } // Sayfa başına kayıt sayısı
        public int TotalRecords { get; set; } // Toplam kayıt sayısı
        public List<int> PageNumbers { get; set; } // Sayfa numaraları
        public int? Price { get; set; }
        public int? CategoryId { get; set; }
    }


    public class PagedResultViewModel<T>
    {
        public T Data { get; set; } // Sayfalandırılmış veri
        public int CurrentPage { get; set; } // Mevcut sayfa
        public int PageSize { get; set; } // Sayfa başına kayıt sayısı
        public int TotalRecords { get; set; } // Toplam kayıt sayısı
        public List<int> PageNumbers { get; set; } // Sayfa numaraları
        public int? Price { get; set; }
        public int? CategoryId { get; set; }


    }
}
