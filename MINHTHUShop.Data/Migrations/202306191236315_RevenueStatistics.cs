namespace MINHTHUShop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RevenueStatistics : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetRevenueStatistics",
                p => new
                {
                    fromDate = p.String(),
                    toDate = p.String()
                }
                ,
                @"
                    select
	                    o.CreateDate as Date,
                        sum(od.Quantity*p.PromotionPrice) as Revenues,
                        sum((od.Quantity*p.PromotionPrice)-(od.Quantity*p.OriginalPrice)) as Benefit
                    from Tb_Order o
	                    inner join Tb_OrderDetail od
                        on o.OrderID = od.OrderId
                        inner join Tb_Product p
                        on od.ProductID  = p.ProductID
                        where o.CreateDate <= cast(@toDate as date) and o.CreateDate >= cast(@fromDate as date)
                        group by o.CreateDate
                    "
                );
        }

        public override void Down()
        {
            DropStoredProcedure("dbo.GetRevenueStatistics");
        }
    }
}