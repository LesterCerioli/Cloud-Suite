using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Configuration;

namespace AdmissionalRegisterService
{
    public partial class AdmissionalRegisterService : IAdmissionalRegisterService
    {
        #region Global Variables
        private PluralUtilityService.PluralUtilitySoapClient _PluralUtilityManager;
        private PluralUtilityService.PluralUtilitySoapClient PluralUtilityManager
        {
            get
            {
                if (_PluralUtilityManager == null)
                    _PluralUtilityManager = new PluralUtilityService.PluralUtilitySoapClient();

                return _PluralUtilityManager;
            }
        }

        private PAMS.PluralAuthenticationManagerSoapClient _PluralAuthenticationManager;
        private PAMS.PluralAuthenticationManagerSoapClient PluralAuthenticationManager
        {
            get
            {
                if (_PluralAuthenticationManager == null)
                    _PluralAuthenticationManager = new PAMS.PluralAuthenticationManagerSoapClient();

                return _PluralAuthenticationManager;
            }
        }

        private PluralEmailService.PluralEmailManagementSoapClient _PluralEmailManager;
        private PluralEmailService.PluralEmailManagementSoapClient PluralEmailManager
        {
            get
            {
                if (_PluralEmailManager == null)
                    _PluralEmailManager = new PluralEmailService.PluralEmailManagementSoapClient();

                return _PluralEmailManager;
            }
        }

        private FinancialService.FinancialServiceSoapClient _FinancialManager;
        private FinancialService.FinancialServiceSoapClient FinancialManager
        {
            get
            {
                if (_FinancialManager == null)
                    _FinancialManager = new FinancialService.FinancialServiceSoapClient();

                return _FinancialManager;
            }
        }
        #endregion

        #region - MaritalStatus
        public List<Model.MaritalModel> GetMaritalStatusList()
        {
            List<Model.MaritalModel> lstMarital = new List<Model.MaritalModel>();
            try
            {
                foreach (var item in PluralUtilityManager.GetMaritalStatus().ToList())
                {
                    lstMarital.Add(new Model.MaritalModel
                    {
                        MaritalStatusId = item.MaritalStatusId,
                        Description = item.Description
                    });
                }

                return lstMarital;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - EducationLevel
        public List<Model.EducationLevelModel> GetEducationLevelList()
        {
            List<Model.EducationLevelModel> lstEducation = new List<Model.EducationLevelModel>();

            try
            {
                foreach (var item in PluralUtilityManager.GetEducationLevel().ToList())
                {
                    lstEducation.Add(new Model.EducationLevelModel
                    {
                        EducationLevelId = item.EducationLevelId,
                        Description = item.Description
                    });
                }

                return lstEducation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - BrazilStateList
        public List<Model.StateModel> GetBrazilState()
        {
            List<Model.StateModel> lstBrazilState = new List<Model.StateModel>();

            try
            {
                foreach (var item in PluralUtilityManager.GetState(null, 26, null).ToList())
                {
                    lstBrazilState.Add(new Model.StateModel
                    {
                        StateId = item.StateId,
                        Name = item.Name
                    });
                }

                return lstBrazilState;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - Country
        public List<Model.CountryModel> GetCountry()
        {
            List<Model.CountryModel> lstCountry = new List<Model.CountryModel>();
            try
            {
                foreach (var item in PluralUtilityManager.GetCountry(null).ToList())
                {
                    lstCountry.Add(new Model.CountryModel
                    {
                        CountryId = item.CountryId,
                        Name = item.Name
                    });
                }

                return lstCountry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - State
        public List<Model.StateModel> GetState(int? CountryId)
        {
            List<Model.StateModel> lstState = new List<Model.StateModel>();

            try
            {
                foreach (var item in PluralUtilityManager.GetState(null, CountryId, null).ToList())
                {
                    lstState.Add(new Model.StateModel
                    {
                        StateId = item.StateId,
                        Name = item.Name
                    });
                }

                return lstState;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - City
        public List<Model.CityModel> GetCity(int? StateId)
        {
            List<Model.CityModel> lstCity = new List<Model.CityModel>();

            try
            {
                foreach (var item in PluralUtilityManager.GetCity(null, StateId, null, null).ToList())
                {
                    lstCity.Add(new Model.CityModel
                    {
                        CityId = item.CityId,
                        Name = item.Name
                    });
                }

                return lstCity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Model.CityModel GetCityById(int cityId)
        {
            try
            {
                var cityField = PluralUtilityManager.GetCity(cityId, null, null, null).SingleOrDefault();

                if (cityField != null)
                    return new Model.CityModel() { CityId = cityField.CityId, StateId = cityField.StateId, CountryId = cityField.CountryId };
                else
                    return new Model.CityModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - Course
        public List<Model.CourseModel> GetCourse()
        {
            List<Model.CourseModel> lstCourse = new List<Model.CourseModel>();
            try
            {
                foreach (DataRow course in PluralUtilityManager.CourseSelect().Tables[0].Rows)
                {
                    lstCourse.Add(new Model.CourseModel
                    {
                        CourseId = Convert.ToInt32(course["CourseId"].ToString()),
                        Name = course["Name"].ToString()
                    });
                }

                return lstCourse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Bank
        public List<Model.BankModel> GetBank(int? bankId)
        {
            var bankList = new List<Model.BankModel>();

            try
            {
                foreach (var item in PluralUtilityManager.GetBank(bankId))
                {
                    bankList.Add(new Model.BankModel
                    {
                        BankId = item.BankId,
                        Name = item.Code + " - " + item.Description
                    });
                }
                return bankList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - Dependent
        public List<Model.RelativeDegreeModel> GetRelativeDegree()
        {
            List<Model.RelativeDegreeModel> lstDegree = new List<Model.RelativeDegreeModel>();
            try
            {
                foreach (DataRow r in PluralAuthenticationManager.UserRelatedIndividualRelativeDegreeSelect().Tables[0].Rows)
                {
                    lstDegree.Add(new Model.RelativeDegreeModel
                    {
                        RelativeDegreeId = Convert.ToInt32(r["UserRelatedIndividualRelativeDegreeId"]),
                        Description = r["Description"].ToString()
                    });
                }
                return lstDegree;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Model.Dependent> GetDependents(int employeeId)
        {
            try
            {
                var dependentsAM = PluralAuthenticationManager.UserRelatedIndividualSelect(employeeId, null, null).Tables[0].Rows;
                var dependents = new List<Model.Dependent>();
                foreach(DataRow dp in dependentsAM)
                {
                    dependents.Add(new Model.Dependent()
                    {
                        Name = dp["Name"].ToString(),
                        Kinship = Convert.ToInt32(dp["UserRelatedIndividualRelativeDegreeId"].ToString()),
                        dtBirth = Convert.ToDateTime(dp["BirthDate"].ToString()),
                        TaxPayerRegistry = dp["CPF"].ToString(),
                        IsDependentIRRF = Convert.ToBoolean(dp["IsIRRFDependent"].ToString())
                    });
                }
                return dependents;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region - Employee
        public bool InsertEmployee(Model.Employee employee, Model.Address address, List<Model.Phone> phoneList, Model.WorkPermit workPermit, Model.GeneralRegistration rg,
                                   Model.PIS pis, Model.MilitaryEnlistment certMilitary, Model.VotersTitle voteTitle, List<Model.Parent> parentList, List<Model.Benefit> benefitList,
                                   Model.Email email, List<Model.Dependent> dependentList, Model.BankAccount bankAccount)
        {
            bool retorno = false;



            try
            {
                var residencialPhone = phoneList.Where(w => w.Type == Model.PhoneType.Residencial).SingleOrDefault();
                var mobilePhone = phoneList.Where(w => w.Type == Model.PhoneType.Mobile).SingleOrDefault();
                var emergencyPhone = phoneList.Where(w => w.Type == Model.PhoneType.Emergency).SingleOrDefault();

                var spouse = parentList.Where(p => p.Type == Model.ParentType.Spouse).SingleOrDefault();
                var father = parentList.Where(p => p.Type == Model.ParentType.Father).SingleOrDefault();
                var mother = parentList.Where(p => p.Type == Model.ParentType.Mother).SingleOrDefault();

                //Metodo antecipado a atualização cadastral
                //employeeBirthDate e RG - forçando data de nascimento e RG do colaborador em parametro, pois, em caso de exception no AM, 
                //é possível dar continuidade no fluxo de email sem a perda das informações
                //InternalEmailNotificationEmployeeSuceeded(employee.EmployeeId, employee.dtBirth, rg.Number);
                
                //string code = "y5JJ3z7e0lP16alpb28h8V6U1k72KhjQtnEZ0An528I=";
                PluralAuthenticationManager.UserUpdate(employee.EmployeeId, employee.Name, null, employee.TaxPayer, employee.dtBirth.Value, employee.CityBirth, address.Description,
                                                        address.Number.ToString(), address.Complement, address.Neighborhood, address.CityId, address.StateId, address.CountryId,
                                                        address.ZipCode, "55", (residencialPhone != null ? residencialPhone.StateCode.ToString() : null),
                                                        (residencialPhone != null ? residencialPhone.Number.ToString() : null), null, null, null, "55",
                                                        (mobilePhone != null ? mobilePhone.StateCode.ToString() : null), (mobilePhone != null ? mobilePhone.Number.ToString() : null),
                                                        null, null, null, null, workPermit.Number, workPermit.Series, workPermit.UfId, pis.Number, rg.Number, rg.EmissionInssuer, 0,
                                                        rg.dtExpedition, certMilitary.Number, voteTitle.Number, voteTitle.Zone, voteTitle.Section, employee.EducationLevelId, employee.Course,
                                                        null, employee.InstitutionEducational, null, employee.MaritalStatusId, (spouse != null ? spouse.Name.ToString() : " "),
                                                        (father != null ? father.Name.ToString() : " "), (father != null ? father.NationalId : 0), (mother != null ? mother.Name.ToString() : " "),
                                                        (mother != null ? mother.NationalId : 0), employee.GenderId, employee.Deficient == 1 ? true : false, employee.Race, bankAccount.BankId,
                                                        bankAccount.Branch, bankAccount.BranchDigit, bankAccount.Account, bankAccount.AccountDigit, null, null, null, null, null, null, null, null, null,
                                                        null, null, null, null, null, null, null, null, null, null, null, null, employee.CountryBirth, employee.NationalRegistry,
                                                        Convert.ToInt32(WebConfigurationManager.AppSettings["MacroCompanyId"].ToString()), (emergencyPhone != null ? emergencyPhone.ContactName : null),
                                                        (emergencyPhone != null ? emergencyPhone.Number.ToString() : null), "", true, null, "55", (emergencyPhone != null ? emergencyPhone.StateCode.ToString() : null),
                                                        workPermit.dtExpedition);


                #region - Benefits
                //var banefitFieldList = new List<Model.Benefit>();
                //foreach (DataRow bn in PluralAuthenticationManager.User_BenefitSelect(employee.EmployeeId, null, null).Tables[0].Rows)
                //{
                //    banefitFieldList.Add(new Model.Benefit
                //    {
                //        BenefitId = Convert.ToInt32(bn["User_BenefitId"].ToString()),
                //        Description = bn["Description"].ToString(),
                //        Value = Convert.ToDecimal(bn["Value"]),
                //        Type = Convert.ToInt32(bn["BenefitId"].ToString()),
                //    });
                //}

                //if (benefitList != null)
                //{
                //    foreach (var benefit in benefitList)
                //    {
                //        bool exists = false;

                //        foreach (var bn in banefitFieldList)
                //        {
                //            if (bn.Description == benefit.Description && bn.Value == benefit.Value && bn.Type == benefit.Type)
                //            {
                //                exists = true;
                //                break;
                //            }
                //        }
                //        if (!exists)
                //            PluralAuthenticationManager.User_BenefitInsert(employee.EmployeeId, benefit.Type, benefit.Value, benefit.Description);
                //    }

                //    //Delete Benefit if not exists in RegisterSubmit
                //    foreach (var included in banefitFieldList)
                //    {
                //        bool isEqual = false;

                //        foreach (var bn in benefitList)
                //        {
                //            if (bn.Value == included.Value && bn.Description == included.Description && bn.Type == included.Type)
                //            {
                //                isEqual = true;
                //                break;
                //            }
                //        }
                //        if (!isEqual)
                //            PluralAuthenticationManager.User_BenefitDelete(employee.EmployeeId, included.BenefitId);
                //    }
                //}
                #endregion

                #region - Dependents
                var dependentFieldList = new List<Model.Dependent>();
                foreach (DataRow dp in PluralAuthenticationManager.UserRelatedIndividualSelect(employee.EmployeeId, null, null).Tables[0].Rows)
                {
                    dependentFieldList.Add(new Model.Dependent
                    {
                        DependentId = Convert.ToInt32(dp["UserRelatedIndividualId"].ToString()),
                        Name = dp["Name"].ToString(),
                        dtBirth = Convert.ToDateTime(dp["BirthDate"].ToString()),
                        Kinship = Convert.ToInt32(dp["UserRelatedIndividualRelativeDegreeId"].ToString()),
                        TaxPayerRegistry = dp["CPF"].ToString(),
                        IsDependentIRRF = Convert.ToBoolean(dp["IsIRRFDependent"].ToString())
                    });
                }

                if (dependentList != null)
                {
                    foreach (var dependent in dependentList)
                    {
                        bool exists = false;

                        foreach (var dp in dependentFieldList)
                        {
                            if (dp.Name == dependent.Name && dp.Kinship == dependent.Kinship && dp.dtBirth == dependent.dtBirth && dp.TaxPayerRegistry == dependent.TaxPayerRegistry && dp.IsDependentIRRF == dependent.IsDependentIRRF)
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (!exists)
                            PluralAuthenticationManager.UserRelatedIndividualInsert(employee.EmployeeId, dependent.Name, Convert.ToByte(dependent.Kinship), dependent.dtBirth, dependent.TaxPayerRegistry, dependent.IsDependentIRRF, null);
                    }

                    //Delete Dependents if not exists in RegisterSubmit
                    foreach (var included in dependentFieldList)
                    {
                        bool isEqual = false;

                        foreach (var dp in dependentList)
                        {
                            if (dp.Name == included.Name && dp.Kinship == included.Kinship && dp.dtBirth == included.dtBirth && dp.TaxPayerRegistry == included.TaxPayerRegistry && dp.IsDependentIRRF == included.IsDependentIRRF)
                            {
                                isEqual = true;
                                break;
                            }
                        }

                        if (!isEqual)
                            PluralAuthenticationManager.UserRelatedIndividualDelete(included.DependentId);
                    }
                }
                #endregion

                #region - Email
                List<Model.Email> emailFieldList = new List<Model.Email>();
                foreach (DataRow em in PluralAuthenticationManager.UserEmailSelect(employee.EmployeeId, null).Tables[0].Rows)
                {
                    emailFieldList.Add(new Model.Email
                    {
                        EmailId = Convert.ToInt32(em["User_EmailId"].ToString()),
                        MailName = em["MailName"].ToString()
                    });
                }

                if (email != null)
                {
                    if (emailFieldList.Where(e => e.MailName == email.MailName).Count() == 0)
                        PluralAuthenticationManager.UserEmailInsert(employee.EmployeeId, email.MailName);

                    foreach (var included in emailFieldList)
                    {
                        bool isEqual = false;

                        if (included.MailName == email.MailName)
                        {
                            isEqual = true;
                            break;
                        }

                        if (!isEqual)
                            PluralAuthenticationManager.UserEmailDelete(employee.EmployeeId, included.EmailId);
                    }
                }

                #endregion

                

                retorno = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public bool HasRegister(string Code)
        {
            bool retorno = false;
            try
            {
                retorno = PluralAuthenticationManager.UserSelect(null, null, null, null, null, null, Code).Tables[0].Rows.Count == 1 ? true : false;
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Model.Employee SelectEmployee(string Code)
        {
            Model.Employee EmpUser = new Model.Employee();

            try
            {
                DataSet empField = PluralAuthenticationManager.UserSelect(null, null, null, null, null, null, Code);

                if (empField.Tables[0].Rows.Count == 1)
                {
                    foreach (DataRow r in empField.Tables[0].Rows)
                    {
                        EmpUser.EmployeeId = Convert.ToInt32(r["UserId"].ToString());
                        EmpUser.Name = r["Name"].ToString();
                        EmpUser.TaxPayer = r["CPF"].ToString();
                        EmpUser.NationalRegistry = r["NationalRegistry"].ToString();
                        EmpUser.dtBirth = String.IsNullOrEmpty(r["BirthDate"].ToString()) ? (DateTime?)null : Convert.ToDateTime(r["BirthDate"].ToString());
                        EmpUser.GenderId = String.IsNullOrEmpty(r["GenderId"].ToString()) ? (int?)null : Convert.ToInt32(r["GenderId"].ToString());
                        EmpUser.Deficient = String.IsNullOrEmpty(r["Handicapped"].ToString()) ? (int?)null : Convert.ToBoolean(r["Handicapped"].ToString()) ? 1 : 0;
                        EmpUser.Race = String.IsNullOrEmpty(r["SkinColorId"].ToString()) ? (int?)null : Convert.ToInt32(r["SkinColorId"].ToString());
                        EmpUser.MaritalStatusId = String.IsNullOrEmpty(r["MaritalStatusId"].ToString()) ? 0 : Convert.ToInt32(r["MaritalStatusId"].ToString());
                        EmpUser.CityBirth = String.IsNullOrEmpty(r["BirthCityId"].ToString()) ? 0 : Convert.ToInt32(r["BirthCityId"].ToString());
                        EmpUser.EducationLevelId = String.IsNullOrEmpty(r["EducationLevelId"].ToString()) ? 0 : Convert.ToInt32(r["EducationLevelId"].ToString());
                        EmpUser.InstitutionEducational = r["EducationalInstitution"].ToString();
                        EmpUser.Course = String.IsNullOrEmpty(r["CourseId"].ToString()) ? 0 : Convert.ToInt32(r["CourseId"].ToString());

                        EmpUser.Parents = new List<Model.Parent>();
                        if (!String.IsNullOrEmpty(r["FatherName"].ToString()))
                        {
                            var fatherBirthCountry = String.IsNullOrEmpty(r["FatherBirthCountryId"].ToString()) ? 0 : Convert.ToInt32(r["FatherBirthCountryId"].ToString());
                            EmpUser.Parents.Add(new Model.Parent { Name = r["FatherName"].ToString(), NationalId = fatherBirthCountry, Type = Model.ParentType.Father });
                        }

                        if(!String.IsNullOrEmpty(r["MotherName"].ToString()))
                        {
                            var motherBirthCountry = String.IsNullOrEmpty(r["MotherBirthCountryId"].ToString()) ? 0 : Convert.ToInt32(r["MotherBirthCountryId"].ToString());
                            EmpUser.Parents.Add(new Model.Parent { Name = r["MotherName"].ToString(), NationalId = motherBirthCountry, Type = Model.ParentType.Mother });
                        }

                        if (!String.IsNullOrEmpty(r["ConsortName"].ToString()))
                            EmpUser.Parents.Add(new Model.Parent { Name = r["ConsortName"].ToString(), NationalId = 0, Type = Model.ParentType.Spouse });

                        EmpUser.Address = new Model.Address
                        {
                            CountryId = String.IsNullOrEmpty(r["AddressCountryId"].ToString()) ? 0 : Convert.ToInt32(r["AddressCountryId"].ToString()),
                            StateId = String.IsNullOrEmpty(r["AddressStateId"].ToString()) ? 0 : Convert.ToInt32(r["AddressStateId"].ToString()),
                            CityId = String.IsNullOrEmpty(r["AddressCityId"].ToString()) ? 0 : Convert.ToInt32(r["AddressCityId"].ToString()),
                            Neighborhood = r["AddressNeighbourhood"].ToString(),
                            ZipCode = r["AddressPostalCode"].ToString(),
                            Number = String.IsNullOrEmpty(r["AddressNumber"].ToString()) ? (int?)null : Convert.ToInt32(r["AddressNumber"].ToString()),
                            Description = r["AddressStreet"].ToString(),
                            Complement = r["AddressExtra"].ToString(),
                        };

                        EmpUser.GenRegister = new Model.GeneralRegistration
                        {
                            Number = r["RG"].ToString(),
                            EmissionInssuer = r["RGSource"].ToString(),
                            dtExpedition = String.IsNullOrEmpty(r["RGIssueDate"].ToString()) ? (DateTime?)null : Convert.ToDateTime(r["RGIssueDate"].ToString())
                        };

                        EmpUser.CertMilitary = new Model.MilitaryEnlistment
                        {
                            Number = r["MilitarDocument"].ToString()
                        };

                        EmpUser.PIS = new Model.PIS
                        {
                            Number = r["PIS"].ToString()
                        };

                        EmpUser.WorkPermit = new Model.WorkPermit
                        {
                            Number = r["CTPS"].ToString(),
                            Series = r["CTPSSerie"].ToString(),
                            UfId = String.IsNullOrEmpty(r["CTPSStateId"].ToString()) ? 0 : Convert.ToInt32(r["CTPSStateId"].ToString()),
                            dtExpedition = String.IsNullOrEmpty(r["CTPSIssueDate"].ToString()) ? (DateTime?)null : Convert.ToDateTime(r["CTPSIssueDate"].ToString())
                        };

                        EmpUser.VoteTitle = new Model.VotersTitle
                        {
                            Number = r["VoterTitle"].ToString(),
                            Zone = r["VoterZone"].ToString(),
                            Section = r["VoterSection"].ToString(),
                        };

                        EmpUser.BankAccount = new Model.BankAccount
                        {
                            BankId = String.IsNullOrEmpty(r["BankId"].ToString()) ? 0 : Convert.ToInt32(r["BankId"].ToString()),
                            Branch = r["BankAgency"].ToString(),
                            BranchDigit = r["BankAgencyDigit"].ToString(),
                            Account = r["BankAccount"].ToString(),
                            AccountDigit = r["BankAccountDigit"].ToString()
                        };

                        EmpUser.Phones = new List<Model.Phone>();
                        if (!String.IsNullOrEmpty(r["PhoneNumber"].ToString()))
                        {
                            var stateCode = String.IsNullOrEmpty(r["PhoneNumberAreaCode"].ToString()) ? 0 : Convert.ToInt32(r["PhoneNumberAreaCode"].ToString());
                            EmpUser.Phones.Add(new Model.Phone { StateCode = stateCode, Number = r["PhoneNumber"].ToString(), Type = Model.PhoneType.Residencial });
                        }

                        if (!String.IsNullOrEmpty(r["MobilePhoneNumber"].ToString()))
                        {
                            var stateCode = String.IsNullOrEmpty(r["MobilePhoneNumberAreaCode"].ToString()) ? 0 : Convert.ToInt32(r["MobilePhoneNumberAreaCode"].ToString());
                            EmpUser.Phones.Add(new Model.Phone { StateCode = stateCode, Number = r["MobilePhoneNumber"].ToString(), Type = Model.PhoneType.Mobile });
                        }

                        if (!String.IsNullOrEmpty(r["EmergencyContactNumber"].ToString()))
                        {
                            var stateCode = String.IsNullOrEmpty(r["EmergencyContactNumberAreaCode"].ToString()) ? 0 : Convert.ToInt32(r["EmergencyContactNumberAreaCode"].ToString());
                            var contactName = r["EmergencyContactName"].ToString();
                            EmpUser.Phones.Add(new Model.Phone { StateCode = stateCode, Number = r["EmergencyContactNumber"].ToString(), Type = Model.PhoneType.Emergency, ContactName = contactName  });
                        }
                    }
                }
                return EmpUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Model.Email SelectEmail(int EmployeeId)
        {
            Model.Email EmpMail = new Model.Email();

            try
            {

                DataRow dr = PluralAuthenticationManager.UserEmailSelect(EmployeeId, null).Tables[0].Rows[0];

                int mailId = string.IsNullOrEmpty(dr["User_EmailId"].ToString()) ? 0 : Convert.ToInt32(dr["User_EmailId"].ToString());
                string mailName = dr["MailName"].ToString();

                if (mailId != 0 && !string.IsNullOrEmpty(mailName))
                {
                    EmpMail.EmailId = mailId;
                    EmpMail.MailName = mailName;
                }

                return EmpMail;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region - Mail
        public void MailSend(string to, string subject, string body)
        {
            try
            {
                PluralEmailManager.MailInsert(null, null, WebConfigurationManager.AppSettings["EmailFrom"].ToString(), to, "", "", subject, body, null, 1, 1, null, null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InternalEmailNotificationEmployeeSuceeded(int userId, DateTime? employeeBirthDate, string employeeRg)
        {
            var user = PluralAuthenticationManager.UserSelect(userId, null, null, null, null, null, null).Tables[0].Rows[0];

            string NewEmployeeAlertDepartmentsId = WebConfigurationManager.AppSettings["NewEmployeeAlertDepartmentsId"].ToString();

            foreach (string departmentStringId in NewEmployeeAlertDepartmentsId.Split(';'))
            {
                int departmentId = Convert.ToInt32(departmentStringId);

                DataSet DataSetCompany = new DataSet();
                DataSetCompany = FinancialManager.FN_CompanySelectById((int)user["CompanyId"]);

                DataSet DataSetBranch = new DataSet();
                DataSetBranch = FinancialManager.FN_BranchSelectbyBranchId((int)user["BranchId"]);

                string name = user["Name"] as string;
                string login = user["Login"] as string;
                DateTime? birthDate = user["BirthDate"] as DateTime?;
                string cpf = user["CPF"] as string;
                string rg = user["RG"] as string;
                string companyName = DataSetCompany.Tables[0].Rows[0]["NOME"] as string;
                string branchName = DataSetBranch.Tables[0].Rows[0]["APELIDO"] as string;
                string departmentName = user["DepartmentName"] as string;
                string immediateSuperiorName = user["ImmediateSuperiorUserName"] as string;
                string managerName = user["ManagerUserName"] as string;
                DateTime? admissionDate = user["AdmissionDate"] as DateTime?;
                string typeEmployee = user["UserTypeDescription"] as string;

                string emailText = "";
                emailText += "<p>Nome: " + name + "</p>";
                emailText += "<p>Login: " + login + "</p>";
                emailText += "<p>Data de nascimento: " + (birthDate.HasValue ? birthDate.Value.ToString("dd/MM/yyyy") : employeeBirthDate.HasValue ? employeeBirthDate.Value.ToString("dd/MM/yyyy") : "") + "</p>";
                emailText += "<p>CPF: " + cpf + "</p>";
                emailText += "<p>RG: " + (!string.IsNullOrEmpty(rg) ? rg : employeeRg) + "</p>";
                emailText += "<p>Empresa / Filial: " + companyName + " / " + branchName + "</p>";
                emailText += "<p>Departamento(s): " + departmentName + "</p>";
                emailText += "<p>Superior Imediato: " + immediateSuperiorName + "</p>";
                emailText += "<p>Gestor: " + managerName + "</p>";
                emailText += "<p>Data de admiss&atilde;o: " + (admissionDate.HasValue ? admissionDate.Value.ToString("dd/MM/yyyy") : "") + "</p>";
                emailText += "<p>Tipo de colaborador:" + typeEmployee + "</p>";


                string subjectText = "Novo colaborador cadastrado";
                string bodyText = "<html><head><title>Sistema de Gente</title><style type='text/css'>html,table{font-family: Calibri,Arial;font-size: 12px;}</style></head><body>Informa&ccedil;&otilde;es sobre o(a) novo(a) colaborador(a):<br>" + emailText + "</body></html>";
                string userResponsibleEmail = "";


                DataTable DataTableUser = PluralAuthenticationManager.UserSelectByDepartmentId(departmentId).Tables[0];

                foreach (DataRow DataRowUser in DataTableUser.Rows)
                {
                    userResponsibleEmail = DataRowUser["Login"].ToString();

                    //Warning the responsibles by department about the new colaborador.
                    MailSend(userResponsibleEmail, subjectText, bodyText);
                }
            }
        }
        #endregion
    }
}
