using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain.model;

namespace domain.service
{
    public interface ISewaDetailService
    {
        IList<SewaDetail> findAllData(String id);
    }
}
