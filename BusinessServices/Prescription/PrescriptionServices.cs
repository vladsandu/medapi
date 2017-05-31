using System;
using AutoMapper;
using BusinessEntities.Prescription;
using DataAccess.UnitOfWork;

namespace BusinessServices.Prescription {
    public class PrescriptionServices : IPrescriptionServices {
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PrescriptionEntity AddPrescriptionForExamination(PrescriptionAddRequest prescriptionRequest)
        {
            var currentExamination =
                _unitOfWork.ExaminationRepository.Get(examination => examination.Id == prescriptionRequest.ExaminationId);
            if (currentExamination == null)
                throw new ArgumentException();

            var prescriptionType = _unitOfWork.PrescriptionTypeRepository.Get(
                type => type.Name == prescriptionRequest.PrescriptionType);
            if (prescriptionType == null)
                throw new ArgumentException();

            var prescriptionStatus = _unitOfWork.PrescriptionStatusRepository.Get(
                status => status.Name == prescriptionRequest.PrescriptionStatus);
            if (prescriptionStatus == null)
                throw new ArgumentException();

            var prescription = new DataAccess.Entities.Prescription.Prescription()
            {
                Examination = currentExamination,
                PrescriptionType = prescriptionType,
                PrescriptionStatus = prescriptionStatus,
                Date = DateTime.Now,
                Days = prescriptionRequest.Days
            };
            _unitOfWork.PrescriptionRepository.Insert(prescription);
            _unitOfWork.Save();
            return Mapper.Map<DataAccess.Entities.Prescription.Prescription, PrescriptionEntity>(prescription);
        }

    }
}