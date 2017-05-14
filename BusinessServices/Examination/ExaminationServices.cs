using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Character;
using BusinessEntities.Examination;
using DataAccess.Entities.Character;
using DataAccess.Entities.Examination;
using DataAccess.UnitOfWork;

namespace BusinessServices.Examination {
    public class ExaminationServices : IExaminationServices{
        private readonly IUnitOfWork _unitOfWork;

        public ExaminationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ExaminationEntity AddExaminationForPatient(int patientId, string examinationTypeName)
        {
            var examinationType = _unitOfWork.ExaminationTypeRepository.Get(type => type.Name == examinationTypeName);
            var patient = _unitOfWork.PatientRepository.Get(currentPatient => currentPatient.Id == patientId);
            var examination = new DataAccess.Entities.Examination.Examination
            {
                Date = DateTime.Now, Patient = patient, ExaminationType = examinationType
            };  
            _unitOfWork.ExaminationRepository.Insert(examination);
            _unitOfWork.Save();
            return Mapper.Map<DataAccess.Entities.Examination.Examination, ExaminationEntity>(examination);
        }

        public List<ExaminationEntity> GetExaminationsForMedic(int medicId)
        {
            var examinations = _unitOfWork.ExaminationRepository.GetMany(examination => examination.Patient.Physician.Id == medicId);
            return examinations?.Select(Mapper.Map<DataAccess.Entities.Examination.Examination, ExaminationEntity>).ToList();
        }
        public List<ExaminationEntity> GetExaminationsForPatient(int patientId)
        {
            var examinations = _unitOfWork.ExaminationRepository.GetMany(examination => examination.Patient.Id == patientId);
            return examinations?.Select(Mapper.Map<DataAccess.Entities.Examination.Examination, ExaminationEntity>).ToList();
        }

        public List<ExaminationTypeEntity> GetExaminationTypes()
        {
            var examinationTypes = _unitOfWork.ExaminationTypeRepository.GetAll();
            return examinationTypes.Select(Mapper.Map<ExaminationType, ExaminationTypeEntity>).ToList();
        }
    }
}