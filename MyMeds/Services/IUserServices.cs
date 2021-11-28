using MyMeds.Models;

namespace MyMeds.Services
{
    public interface IUserServices
    {
        Task<bool> PasswordSignIn(string user, string password);
        LogonModel GrabDataForUser(string user);
        IList<MedicationModel> GrabMedicationsOnlyToList(string user);
        Task CreateMedicationTask(MedicationModel model, int loginId);
        Task DeleteMedicationTask(MedicationModel model, int logonId);
        Task UpdateMedicationTask(MedicationModel model, int logonId);
    }
}
