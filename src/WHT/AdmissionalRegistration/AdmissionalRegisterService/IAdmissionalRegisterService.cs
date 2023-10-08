using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdmissionalRegisterService
{
    [ServiceContract]
    public partial interface IAdmissionalRegisterService
    {
        #region - MaritalStatus
        [OperationContract]
        List<Model.MaritalModel> GetMaritalStatusList();
        #endregion

        #region - EducationLevel
        [OperationContract]
        List<Model.EducationLevelModel> GetEducationLevelList();
        #endregion

        #region - Country
        [OperationContract]
        List<Model.CountryModel> GetCountry();
        #endregion

        #region - State
        [OperationContract]
        List<Model.StateModel> GetBrazilState();

        [OperationContract]
        List<Model.StateModel> GetState(int? CountryId);
        #endregion

        #region - City
        [OperationContract]
        List<Model.CityModel> GetCity(int? StateId);

        [OperationContract]
        Model.CityModel GetCityById(int cityId);
        #endregion

        #region - Course
        [OperationContract]
        List<Model.CourseModel> GetCourse();
        #endregion

        #region - Bank
        [OperationContract]
        List<Model.BankModel> GetBank(int? bankId);
        #endregion

        #region - Dependent
        [OperationContract]
        List<Model.RelativeDegreeModel> GetRelativeDegree();

        [OperationContract]
        List<Model.Dependent> GetDependents(int employeeId);
        #endregion

        #region - Employee
        [OperationContract]
        bool InsertEmployee(Model.Employee Employee, Model.Address EmpAddress, List<Model.Phone> EmpLstPhone, Model.WorkPermit EmpWorkPerm, Model.GeneralRegistration EmpRG,
                            Model.PIS EmpPIS, Model.MilitaryEnlistment EmpCertMilitary, Model.VotersTitle EmpVoteTitle, List<Model.Parent> EmpLstParent, List<Model.Benefit> EmpLstBen,
                            Model.Email EmpEmail, List<Model.Dependent> EmpLstDep, Model.BankAccount bankAccount);

        [OperationContract]
        bool HasRegister(string Code);

        [OperationContract]
        Model.Employee SelectEmployee(string Code);

        [OperationContract]
        Model.Email SelectEmail(int EmployeeId);
        #endregion

        #region - Mail
        [OperationContract]
        void MailSend(string to, string subject, string body);
        #endregion
    }
}
