namespace Netflix_Server.Models.UserGroup
{
    public class PricingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } // Название плана
        public decimal Price { get; set; } // Цена плана
        public string Period { get; set; } // Период, к которому относится цена (например, "/ month")
        public string Description { get; set; } // Описание плана
        public ICollection<Feature>? Features { get; set; }
    }
}
