namespace UniversityProject.Core.Mapping.DoctorMapping;

public partial class DoctorMapping
{
    public void GetDoctorMap()
    {
        CreateMap<Doctor, GetDoctorDto>()
            .ForMember(d => d.DepartmentName, opt => opt.MapFrom(d => d.Department.Name));
    }
}
