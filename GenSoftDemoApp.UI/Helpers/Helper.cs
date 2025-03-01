namespace GenSoftDemoApp.UI.Helpers
{
    public static class Helper
    {
        public static List<int> GeneratePageNumbers(int totalPages, int currentPage, int maxPagesToShow = 5)
        {
            var pageNumbers = new List<int>();

            if (totalPages <= maxPagesToShow)
            {
                for (int i = 1; i <= totalPages; i++)
                {
                    pageNumbers.Add(i);
                }
            }
            else
            {
                int startPage = Math.Max(1, currentPage - (maxPagesToShow / 2));
                int endPage = Math.Min(totalPages, currentPage + (maxPagesToShow / 2));

                if (startPage > 1)
                {
                    pageNumbers.Add(1);
                    if (startPage > 2)
                    {
                        pageNumbers.Add(-1);
                    }
                }

                for (int i = startPage; i <= endPage; i++)
                {
                    pageNumbers.Add(i);
                }

                if (endPage < totalPages)
                {
                    if (endPage < totalPages - 1)
                    {
                        pageNumbers.Add(-1);
                    }
                    pageNumbers.Add(totalPages);
                }
            }

            return pageNumbers;
        }
    }
}
