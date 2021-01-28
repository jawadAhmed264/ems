using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ems.DTO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class EmpName
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }
    }

    public class Age
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }
    }

    public class Gender
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }
    }

    public class Contact
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }
    }

    public class DepartmentDepName
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }
    }

    public class Salary
    {
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("matchMode")]
        public string MatchMode { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }
    }

    public class Filters
    {
        [JsonProperty("EmpName")]
        public List<EmpName> EmpName { get; set; }

        [JsonProperty("Age")]
        public List<Age> Age { get; set; }

        [JsonProperty("Gender")]
        public List<Gender> Gender { get; set; }

        [JsonProperty("Contact")]
        public List<Contact> Contact { get; set; }

        [JsonProperty("Department.DepName")]
        public List<DepartmentDepName> DepartmentDepName { get; set; }

        [JsonProperty("Salary")]
        public List<Salary> Salary { get; set; }
    }

    public class Root
    {
        [JsonProperty("first")]
        public int First { get; set; }

        [JsonProperty("rows")]
        public int Rows { get; set; }
        [JsonProperty("sortField")]
        public string SortField { get; set; }

        [JsonProperty("sortOrder")]
        public int SortOrder { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("globalFilter")]
        public object GlobalFilter { get; set; }
    }




}
