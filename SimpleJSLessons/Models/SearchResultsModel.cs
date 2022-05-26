using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleJSLessons.Models
{
    public class SearchResultsModel
    {
        public SearchResultsModel(DataDataTable data, double weight)
        {
            this.item = data;
            this.weight = weight;
        }
        public DataDataTable item { get; set; }
        public double weight { get; set; }
    }
}
