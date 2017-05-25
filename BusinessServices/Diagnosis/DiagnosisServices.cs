using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Diagnosis;
using DataAccess.UnitOfWork;

namespace BusinessServices.Diagnosis {
    public class DiagnosisServices : IDiagnosisServices {
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosisServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DiagnosisEntity> GetDiagnosticsForPatient(int patientId)
        {
            var diagnostics =
                _unitOfWork.DiagnosisRepository.GetMany(diagnosis => diagnosis.Examination.Patient.Id == patientId);
            return diagnostics?.Select(Mapper.Map<DataAccess.Entities.Diagnosis.Diagnosis, DiagnosisEntity>).ToList();
        }

        public List<DiagnosisEntity> GetDiagnosticsForExamination(int examinationId)
        {
            var diagnostics =
                _unitOfWork.DiagnosisRepository.GetMany(diagnosis => diagnosis.Examination.Id == examinationId);
            return diagnostics?.Select(Mapper.Map<DataAccess.Entities.Diagnosis.Diagnosis, DiagnosisEntity>).ToList();
        }

        public DiagnosisEntity AddDiagnosis(DiagnosisAddRequest diagnosisAddRequest)
        {
            var currentExamination =
                _unitOfWork.ExaminationRepository.Get(examination => examination.Id == diagnosisAddRequest.ExaminationId);
            if (currentExamination == null)
                throw new ArgumentException();

            var currentCondition = _unitOfWork.ConditionRepository.Get(condition => condition.Id == diagnosisAddRequest.ConditionId);
            if (currentCondition == null)
                throw new ArgumentException();

            var diagnosis = new DataAccess.Entities.Diagnosis.Diagnosis
            {
                Examination = currentExamination,
                Condition = currentCondition,
                Observations = diagnosisAddRequest.Observations
            };
            _unitOfWork.DiagnosisRepository.Insert(diagnosis);
            _unitOfWork.Save();
            return Mapper.Map<DataAccess.Entities.Diagnosis.Diagnosis, DiagnosisEntity>(diagnosis);
        }
    }
}