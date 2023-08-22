namespace MyApi.Models
{
    public class Items
    {
        public int items_id { get; set; }
        public string items_name_en { get; set; }
        public string items_name_ar { get; set; }
        public string items_desc_en { get; set; }
        public string items_desc_ar { get; set; }
        public string items_image { get; set; }
        public int items_count { get; set; }
        public int items_active { get; set; }
        public float items_price { get; set; }
        public int items_discount { get; set; }
        public int items_cat { get; set; }
        public int categories_id { get; set; }
        public String categories_name_en { get; set; }
        public String categories_name_ar { get; set; }
        public String categories_image { get; set; }
    }
}
