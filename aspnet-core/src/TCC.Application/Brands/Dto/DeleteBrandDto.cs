using System;
using System.Collections.Generic;
using System.Text;

/*
 * Need this class because DeleteBrand method takes in string Id parameter but must be mapped to a object.
 * Cannot use EntityDto provided by boilerplate because it's Id property is of int type but Id stored by MongoDB is of type ObjectId
 */
namespace TCC.Brands.Dto
{
    public class DeleteBrandDto
    {
        public string Id { get; set; }
    }
}
