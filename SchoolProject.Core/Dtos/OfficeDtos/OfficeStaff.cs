namespace UniversityProject.Core.Dtos.OfficeDtos;

public class OfficeStaff
{
    public string For { get; set; }

    public List<Staff> staffs { get; set; } = [];
}

public class Staff
{
    public int Id { get; set; }
    public string Name { get; set; }
}
