using AspNetCoreMvc.Models;
using System.Collections.Generic;

namespace AspNetCoreMvc.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Comida> ComidasPreferidas { get; set; }
    }
}
