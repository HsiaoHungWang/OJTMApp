using System;
using System.Collections.Generic;

namespace OJTMApp.Models;

public partial class Order
{
    //PK
    public int OrderId { get; set; }

    //FK
    public string? CustomerId { get; set; }

    //FK
    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public decimal? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }



    public virtual Customer? Customer { get; set; } //Customers Table  1個訂單 > 1個客戶

    public virtual Employee? Employee { get; set; } //Employees Table  1個訂單 > 1個員工

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Shipper? ShipViaNavigation { get; set; }
}
