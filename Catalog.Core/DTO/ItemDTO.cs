using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.DTO
{
    public class ItemDTO
    {
        public Guid Id {  get; set; }
        public string Name {  get; set; }
        public decimal Price {  get; set; }
        public DateTimeOffset CreatedDate {  get; set; }
    }
}
