using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Character;
using BusinessEntities.Staff;
using DataAccess.Entities.Character;
using DataAccess.UnitOfWork;

namespace BusinessServices.Staff {
    public class StaffServices : IStaffServices{
        private readonly IUnitOfWork _unitOfWork;

        public StaffServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PatientEntity> GetPatients(int medicId)
        {
            var patients = _unitOfWork.PatientRepository.GetMany(patient => patient.Physician.Id == medicId);
            return patients?.Select(patient => Mapper.Map<Patient, PatientEntity>(patient)).ToList();
        }

        public StaffEntity GetStaffById(int staffId)
        {
            var staffModel = _unitOfWork.StaffRepository.Get(staff => staff.Id == staffId);
            return Mapper.Map<DataAccess.Entities.Staff.Staff, StaffEntity>(staffModel);
        }
    }
}