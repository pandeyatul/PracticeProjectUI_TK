namespace PracticeProjectUI_TK.Utility
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }//5
        public int TotalItems { get; set; }//34
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);// 34/5=6.8=7  
        public bool Previous => PageNumber > 1;
        public bool Next => PageNumber < TotalPages;

    }
}
