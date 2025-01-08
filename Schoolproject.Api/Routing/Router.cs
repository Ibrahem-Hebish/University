namespace UniversityProject.Api.Routing
{
    public static class Router
    {
        public const string rule = "Api/V1/";
        public static class StudentRouter
        {
            public const string postfix = rule + "Student/";

            public const string GetById = postfix + "id";

            public const string GetAll = postfix + "GetAll";

            public const string GetStudentCourses = postfix + "GetStudentCourses/{Id}";

            public const string GetStudentSections = postfix + "GetStudentSections/{Id}";

            public const string GetStudentSchedule = postfix + "GetStudentSchedule/{Id}";

            public const string GetByName = postfix + "name";

            public const string GroupBySubname = postfix + "GroupBySubname";

            public const string GroupByDepname = postfix + "GroupByDepname";

            public const string AddNewStudent = postfix + "AddNewStudent";

            public const string DeleteStudent = postfix + "DeleteStudent";

            public const string UpdateStudent = postfix + "UpdateStudent";

            public const string Paginate = postfix + "Paginate";

        }

        public static class UserRouter
        {
            public const string postfix = rule + "User/";

            public const string GetById = postfix + "{id}";

            public const string GetUsers = postfix + "GetUsers";

            public const string AddNewUser = postfix + "AddNewUser";

            public const string DeleteUser = postfix + "DeleteUser";

            public const string UpdateUser = postfix + "UpdateUser";

            public const string Paginate = postfix + "Paginate";

            public const string ChangePassword = postfix + "ChangePassword";

            public const string AddRoleToUser = postfix + "AddRoleToUser";

            public const string SendCodeToResetPassword = postfix + "SendCodeToResetPassword";

            public const string ConfirmCodeForResetPassword = postfix + "ConfirmCodeForResetPassword";

            public const string ResetPassword = postfix + "ResetPassword";

            public const string CheckIfEmailExsist = postfix + "CheckIfEmailExsist/{Email}";
        }
        public static class AuthonticationRouter
        {
            public const string postfix = rule + "Authontication/";

            public const string SignIn = postfix + "SignIn";

            public const string RefreshToken = postfix + "RefreshToken";

            public const string VakidateToken = postfix + "VakidateToken";

            public const string ConfirmEmail = "/Authontication/ConfirmEmail";

            public const string GoogleResponse = postfix + "GoogleResponse";

            public const string SignInWithGoogle = postfix + "SignInWithGoogle";

        }

        public static class RoleRouter
        {
            public const string postfix = rule + "Role/";

            public const string GetRole = postfix + "GetRole";

            public const string GetRoles = postfix + "GetRoles";

            public const string AddRole = postfix + "AddRole";

            public const string DeleteRole = postfix + "DeleteRole";

            public const string UpdateRole = postfix + "UpdateRole";

            public const string ManageUserRoles = postfix + "ManageUserRoles";

            public const string ManageUserClaims = postfix + "ManageUserClaims";

            public const string Updateuserclaims = postfix + "Updateuserclaims";
        }

        public static class EmailRouter
        {
            public const string postfix = rule + "Email/";

            public const string SendEmail = postfix + "SendEmail";

        }
        public static class DoctorRouter
        {
            public const string postfix = rule + "Doctor/";

            public const string Get = postfix + "Get/{id}";

            public const string GetAll = postfix + "GetAll";

            public const string GetDoctorCourses = postfix + "GetCourses/{id}";

            public const string Delete = postfix + "Delete/{id}";

            public const string AddDoctor = postfix + "Add";

            public const string ChangeDoctorOffice = postfix + "ChangeOffice";

        }
        public static class TeachingAssistant
        {
            public const string postfix = rule + "TeachingAssistant/";

            public const string Get = postfix + "Get/{id}";

            public const string GetAll = postfix + "GetAll";

            public const string Delete = postfix + "Delete/{id}";

            public const string AddTeachingAssistant = postfix + "Add";

            public const string ChangeOffice = postfix + "ChangeOffice";
            public const string AttachSectionToTeachingAssistant = postfix + "AttachSectionToTeachingAssistant";

        }
        public static class Section
        {
            public const string postfix = rule + "Section/";

            public const string Get = postfix + "Get/{id}";

            public const string GetAll = postfix + "GetAll";

            public const string GetAllInSpecificTerm = postfix + "GetAllInSpecificTerm";

            public const string GetSectionTeachingAssistant = postfix + "GetSectionTeachingAssistant";

            public const string Delete = postfix + "Delete/{id}";

            public const string AddTeachingAssistant = postfix + "Add";

        }

        public static class Course
        {
            public const string postfix = rule + "Course/";

            public const string Get = postfix + "Get/{id}";

            public const string GetAll = postfix + "GetAll";

            public const string GetAllInSpecificTerm = postfix + "GetAllInSpecificTerm";

            public const string GetCourseDoctor = postfix + "GetCourseDoctor";

            public const string Delete = postfix + "Delete/{id}";

            public const string AddTeachingAssistant = postfix + "Add";

        }

        public static class Hall
        {
            public const string postfix = rule + "Hall/";

            public const string GetById = postfix + "Get/{Name}";

            public const string GetAll = postfix + "GetAll";

            public const string Delete = postfix + "Delete/{Name}";

            public const string ChangeName = postfix + "ChangeName";
        }

        public static class Lab
        {
            public const string postfix = rule + "Lab/";

            public const string GetById = postfix + "Get/{Name}";

            public const string GetAll = postfix + "GetAll";

            public const string Delete = postfix + "Delete/{Name}";

            public const string ChangeName = postfix + "ChangeName";
        }

        public static class Office
        {
            public const string postfix = rule + "Office/";

            public const string GetById = postfix + "Get/{Name}";

            public const string GetAll = postfix + "GetAll";

            public const string GetStaff = postfix + "GetStaff/{Name}";

            public const string Delete = postfix + "Delete/{Name}";

            public const string ChangeName = postfix + "ChangeName";
        }
    }
}
