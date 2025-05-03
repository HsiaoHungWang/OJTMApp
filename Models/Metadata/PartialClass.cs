using Microsoft.AspNetCore.Mvc;
using OJTMApp.Models.Metadata;

namespace OJTMApp.Models
{
    [ModelMetadataTypeAttribute(typeof(ShipperMetadata))]
    public partial class Shipper
    {
    }

   [ModelMetadataTypeAttribute(typeof(ProductMetadata))]
    public partial class Product
    {
       
    }
}
