using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.Models
{
    public interface IUserInfoRepository
    {
        public void UpdateStudentInfos(MStudentInformations mStudentInformations);
        public void SaveStudentInfos(MStudentInformations mStudentInformations);
        public void FindStudentInfos(MStudentInformations mStudentInformations);
        public void AddStudentInfos(MStudentInformations mStudentInformations);
        public void RemoveStudentInfos(MStudentInformations mStudentInformations);

        public void Foto();
    }
}
