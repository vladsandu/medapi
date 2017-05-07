using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Character;
using DataAccess.Entities.Character;
using DataAccess.UnitOfWork;

namespace BusinessServices.Character {
    public class PatientServices : IPatientServices{
        private readonly IUnitOfWork _unitOfWork;

        public PatientServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PatientEntity> GetPatients(int medicId)
        {
            var patients = _unitOfWork.PatientRepository.GetMany(patient => patient.Physician.Id == medicId);
            return patients?.Select(patient => Mapper.Map<Patient, PatientEntity>(patient)).ToList();
        }
    }
}