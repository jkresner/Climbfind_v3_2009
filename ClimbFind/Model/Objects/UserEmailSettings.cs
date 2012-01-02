
namespace ClimbFind.Model.Objects
{
    public class UserEmailSettings
    {
        public bool UserMadeSPAMComplaint { get; set; }
        public bool UserRequestedNoMail { get; set; }        
        public bool UserRequestedNoRoleCalls { get; set; }
        public bool SendingToAddressBounced { get; set; }
    }
}
