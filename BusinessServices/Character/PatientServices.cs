using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities.Character;
using DataAccess.Entities.Character;
using DataAccess.UnitOfWork;

namespace BusinessServices.Character {
    public class PatientServices : IPatientServices {
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

        public PatientEntity AddPatient(int medicId, string cnp)
        {
            var physician = _unitOfWork.PhysicianRepository.Get(medic => medic.Id == medicId);
            if (physician == null)
                return null;
            var person = _unitOfWork.PersonRepository.Get(currentPerson => currentPerson.Cnp == cnp);
            if (person == null || person.DateOfDeath.HasValue)
                return null;
            var existingPatient =
                _unitOfWork.PatientRepository.Get(
                    currentPatient => currentPatient.Physician.Id == medicId &&
                                      currentPatient.Person.Cnp == cnp &&
                                      currentPatient.EndDate == null);
            if (existingPatient != null)
                return null;
            var patient = new Patient {Person = person, StartDate = DateTime.Now, Physician = physician};
            _unitOfWork.PatientRepository.Insert(patient);
            _unitOfWork.Save();
            return Mapper.Map<Patient, PatientEntity>(patient);
        }
    }
}