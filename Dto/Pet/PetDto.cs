using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreDemo.dto.Pet
{
    public class PetDto
    {
        public Int64? Id { get; set; }
        public PetCategoryDto Category { get; set; }
        public IList<TagDto> Tags { get; set; }
        public IList<string> PhotoUrls { get; set; }

        public string Name { get; set; }
        public string Status { get; set; }

    }
}
