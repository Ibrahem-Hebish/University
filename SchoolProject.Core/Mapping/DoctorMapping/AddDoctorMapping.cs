namespace UniversityProject.Core.Mapping.DoctorMapping;

public partial class DoctorMapping
{
    public void AddDoctorMap()
    {
        CreateMap<AddNewDoctor, Doctor>();
    }
}
