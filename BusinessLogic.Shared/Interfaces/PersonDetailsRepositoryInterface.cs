using BusinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Shared.Interfaces
{
    public interface PersonDetailsRepositoryInterface
    {
        public List<PersonDetailsModel> GetPersonDetails();
    }
}
