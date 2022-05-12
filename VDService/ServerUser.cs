using System.ServiceModel;

namespace VDService
{
    internal class ServerUser
    {
        public int Id { get; set; }
        public OperationContext OperationContext { get; set; }
    }
}
