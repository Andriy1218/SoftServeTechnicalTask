using SoftServerTechnicalTask.Domain.Model;
using System.Runtime.Serialization;

namespace SoftServeTechnicalTask.Application.Commands.Organizations
{
    [DataContract]
    public class AddCommand
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Owner { get; set; }

        [DataMember]
        public OrganizationType OrganizationType { get; set; }
    }
}
